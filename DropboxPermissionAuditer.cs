using MetroFramework.Forms;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework;
using System.Net;
using Microsoft.Win32;
using System.Threading;

namespace DBPermissionAuditer
{

    public partial class DropboxMembershipAuditer : MetroForm
    {
        public DropboxMembershipAuditer()
        {       
            InitializeComponent();
        }       
        public void EndProgressBar()
        {
            pbMemberInformationProgress.Value = 100;
        }
        public void SVCsvSave_FileOk(object sender, CancelEventArgs e)
        {
            SaveFileDialog sf = (SaveFileDialog)sender;
            txtExportCSV.Text = sf.FileName;
        }
        public static bool registryValueExists(string hive_HKLM_or_HKCU, string registryRoot, string valueName)
        {
            RegistryKey root;
            switch (hive_HKLM_or_HKCU.ToUpper())
            {
                case "HKLM":
                    root = Registry.LocalMachine.OpenSubKey(registryRoot, false);
                    break;
                case "HKCU":
                    root = Registry.CurrentUser.OpenSubKey(registryRoot, false);
                    break;
                default:
                    throw new System.InvalidOperationException("parameter registryRoot must be either \"HKLM\" or \"HKCU\"");
            }

            if (root.GetValue(valueName) == null)
                return false;
            else
                return true;
        }
        public class DropboxMemberCallLimit
        {
            public int limit { get; set; }
        }
        public class Profile
        {
            public string given_name { get; set; }
            public string surname { get; set; }
            public string status { get; set; }
            public string member_id { get; set; }
            public string email { get; set; }
            public string external_id { get; set; }
            public List<object> groups { get; set; }
        }
        public class Permissions
        {
            public bool is_admin { get; set; }
        }
        public class Member
        {
            public Profile profile { get; set; }
            public Permissions permissions { get; set; }
        }
        public class MemberIDs
        {
            public List<Member> members { get; set; }
        }
        public class SearchResult
        {
            public string size { get; set; }
            public string rev { get; set; }
            public bool thumb_exists { get; set; }
            public int bytes { get; set; }
            public string modified { get; set; }
            public string path { get; set; }
            public bool is_dir { get; set; }
            public bool is_deleted { get; set; }
            public string icon { get; set; }
            public string root { get; set; }
            public string mime_type { get; set; }
            public int revision { get; set; }
        }
        public class Owner
        {
            public Membership owner { get; set; }
        }
        public class User
        {
            public int uid { get; set; }
            public string display_name { get; set; }
            public bool same_team { get; set; }
            public string member_id { get; set; }
        }
        public class Membership
        {
            public User user { get; set; }
            public string access_type { get; set; }
            public bool active { get; set; }
        }
        public class SharedFolders
        {
            public string shared_folder_id { get; set; }
            public string shared_folder_name { get; set; }
            public string path { get; set; }
            public string access_type { get; set; }
            public string shared_link_policy { get; set; }
            public User owner { get; set; }
            public List<object> groups { get; set; }
            public List<Membership> membership { get; set; }
        }
        public class DBUserBeingProcessed
        {
            public string Name { get; set; }
        }
        public void OnClosing(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void ValidateAccessToken()
        {
            if (txtAccessToken.Text.Length == 0)
            {
                throw new Exception("Access token is empty.");
            }
        }
        public static void CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                }
            }
            catch
            {
                throw new Exception("The computer you're using has no internet connection.");
            }
        }
        public async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                CheckForInternetConnection();
                ValidateAccessToken();
                ClearGridView();
                await GetMemberIDs();
                LoadingGifVisible(false);
            }
            catch (Exception exp)
            {
                txtStatus.Text = "Error occurred during execution";
                LoadingGifVisible(false);
                MetroFramework.MetroMessageBox.Show(this, "Error: " + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        public void LoadingGifVisible(bool show)
        {
            if (show)
            {
                imgLoadingGif.Visible = true;
            }
            else
            {
                imgLoadingGif.Visible = false;
            }
        }
        public async Task GetMemberIDs()
        {
            string content;
            MemberIDs memberIDs = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.dropbox.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + txtAccessToken.Text);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                var limit = GetLimit();
                var response = await client.PostAsJsonAsync("1/team/members/list", limit );
                content = await response.Content.ReadAsStringAsync();

                memberIDs = new JavaScriptSerializer().Deserialize<MemberIDs>(content);
            }

            if (memberIDs.members == null)
            {
                throw new Exception(content.Replace("{", "").Replace("}", "").Replace("\"", " "));
            }
            else if (memberIDs.members != null)
            {
                int rowcount = 0;
                pbMemberInformationProgress.Value = 0;

                foreach (var DBmem in memberIDs.members)
                {

                    Member mem = (Member)DBmem;
                    if (mem.profile.status == "active")
                    {
                        LoadingGifVisible(true);
                        txtStatus.Text = "Processing: " + DBmem.profile.given_name;
                        await GetDropboxPermissionsObj(mem.profile.member_id, mem.profile.given_name, rowcount);
                        pbMemberInformationProgress.Value += 100 / memberIDs.members.Count;
                        rowcount += 1;
                    }
                }

                if (txtExportCSV.Text.Length != 0)
                {
                    txtStatus.Text = "Saving CSV";
                    SaveCSV();
                }

                txtStatus.Text = "Completed";
                pbMemberInformationProgress.Value = 100;
            }

        }
        public DropboxMemberCallLimit GetLimit()
        {
            var limit = new DropboxMemberCallLimit();
            limit.limit = 1000;

            return limit;
        }
        public async Task GetDropboxPermissionsObj(string memberID, string given_name, int rowcount)
        {
            string content;
            SharedFolders[] results = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.dropbox.com");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + txtAccessToken.Text);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("X-Dropbox-Perform-As-Team-Member", memberID);

                    var response = await client.GetAsync("/1/shared_folders?include_membership=true");
                    content = await response.Content.ReadAsStringAsync();

                    results = new JavaScriptSerializer().Deserialize<SharedFolders[]>(content);

                }

            if (results.Length != 0)
            {
                await GridView(results, given_name, rowcount);
            }
            else
            {
                throw new Exception("Error occurred.");
            }
        }
        public async Task GridView(SharedFolders[] results, string given_name, int rowcount)
        {
            SetGridViewColumns();
            PopulateGridView(results,given_name, rowcount);
        }
        public void PopulateGridView(SharedFolders[] results, string given_name, int rowcount)
        {

            foreach (var result in results)
            {
                bool isThereAlready = CheckFolderIDExist(result.shared_folder_id);

                if (!isThereAlready)
                {


                    if (chkTeamFoldersOnly.Checked == false)
                    {
                        if (result.owner == null || result.owner.same_team == true)
                        {
                            var rowcount2 = DVGResults.Rows.Add();

                            DVGResults.Rows[rowcount2].Cells[0].Value = result.shared_folder_name;
                            if (result.owner != null)
                            {
                                DVGResults.Rows[rowcount2].Cells[1].Value = result.owner.display_name;
                            }
                            else
                            {
                                DVGResults.Rows[rowcount2].Cells[1].Value = "No owner";
                            }
                            DVGResults.Rows[rowcount2].Cells[2].Value = result.shared_folder_id;

                            StringBuilder sb = new StringBuilder();

                            int differentteam = 0;
                            foreach (var member in result.membership)
                            {
                                User mem = (User)member.user;
                                if (mem.same_team == false)
                                {
                                    differentteam += 1;
                                }
                            }

                            if (result.membership.Count != 0)
                            {

                                int intcounter = 0;
                                foreach (var member in result.membership)
                                {
                                    User mem = (User)member.user;

                                    if (chkExternalAccess.Checked)
                                    {
                                        if (mem.same_team == false)
                                        {
                                            sb.Append(mem.display_name);

                                            if (intcounter != differentteam - 1 && differentteam != 1)
                                            {
                                                sb.Append(" | ");
                                                intcounter++;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        sb.Append(mem.display_name);

                                        if (intcounter != result.membership.Count - 1 && result.membership.Count != 1)
                                        {
                                            sb.Append(" | ");
                                            intcounter++;
                                        }
                                    }

                                }
                            }
                            else
                            {
                                DVGResults.Rows.Remove(DVGResults.Rows[rowcount2]);
                            }

                            if (chkExternalAccess.Checked)
                            {
                                if (sb.ToString().Length != 0 || differentteam != 0)
                                {
                                    DVGResults.Rows[rowcount2].Cells[3].Value = sb.ToString();
                                }
                                else
                                {
                                    DVGResults.Rows.Remove(DVGResults.Rows[rowcount2]);
                                }

                            }
                            else
                            {
                                if (sb.ToString().Length != 0)
                                {
                                    DVGResults.Rows[rowcount2].Cells[3].Value = sb.ToString();
                                }
                                else
                                {
                                    DVGResults.Rows.Remove(DVGResults.Rows[rowcount2]);
                                }
                            }
                        }

                    }

                }

                if (chkTeamFoldersOnly.Checked)
                {
                    var rowcount2 = DVGResults.Rows.Add();

                    DVGResults.Rows[rowcount2].Cells[0].Value = result.shared_folder_name;
                    if (result.owner != null)
                    {
                        DVGResults.Rows[rowcount2].Cells[1].Value = result.owner.display_name;
                    }
                    else
                    {
                        DVGResults.Rows[rowcount2].Cells[1].Value = "No owner";
                    }
                    DVGResults.Rows[rowcount2].Cells[2].Value = result.shared_folder_id;

                    StringBuilder sb = new StringBuilder();

                    int differentteam = 0;
                    foreach (var member in result.membership)
                    {
                        User mem = (User)member.user;
                        if (mem.same_team == false)
                        {
                            differentteam += 1;
                        }
                    }

                    if (result.membership.Count != 0)
                    {
                        var intcounter = 0;

                        foreach (var member in result.membership)
                        {
                            User mem = (User)member.user;

                            if (chkExternalAccess.Checked)
                            {
                                if (mem.same_team == false)
                                {
                                    sb.Append(mem.display_name);

                                    if (intcounter != differentteam - 1 && differentteam != 1)
                                    {
                                        sb.Append(" | ");
                                        intcounter++;
                                    }
                                }
                            }
                            else
                            {
                                sb.Append(mem.display_name);

                                if (intcounter != result.membership.Count - 1 && result.membership.Count != 1)
                                {
                                    sb.Append(" | ");
                                    intcounter++;
                                }
                            }

                        }
                    }
                    else
                    {
                        DVGResults.Rows.Remove(DVGResults.Rows[rowcount2]);
                    }

                    if (chkExternalAccess.Checked)
                    {
                        if (sb.ToString().Length != 0 || differentteam != 0)
                        {
                            DVGResults.Rows[rowcount2].Cells[3].Value = sb.ToString();
                        }
                        else
                        {
                            DVGResults.Rows.Remove(DVGResults.Rows[rowcount2]);
                        }

                    }
                    else
                    {
                        if (sb.ToString().Length != 0)
                        {
                            DVGResults.Rows[rowcount2].Cells[3].Value = sb.ToString();
                        }
                        else
                        {
                            DVGResults.Rows.Remove(DVGResults.Rows[rowcount2]);
                        }
                    }


                }
            }

        }
        public void ClearGridView()
        {
            DVGResults.Columns.Clear();
            DVGResults.Rows.Clear();
        }
        public void SetGridViewColumns()
        {
            if (DVGResults.Columns.Count == 0)
            {
                DVGResults.Columns.Add("Folder", "Folder");
                DVGResults.Columns.Add("Owner", "Owner");
                DVGResults.Columns.Add("Folder ID", "Folder ID");
                DVGResults.Columns.Add("Shared with", "Shared with");
            }
        }
        public bool CheckFolderIDExist(string folderid)
        {
            foreach (var row in DVGResults.Rows)
            {
                DataGridViewRow row1 = (DataGridViewRow)row;
                string currentrowvalue = Convert.ToString(row1.Cells[2].Value);
                if (currentrowvalue == folderid)
                {
                    return true;
                }
               
            }
            return false;
        }
        public void SaveCSV()
        {
            if (DVGResults.RowCount != 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();

                using (StreamWriter sw = new StreamWriter(File.Open(txtExportCSV.Text, FileMode.OpenOrCreate)))
                {

                    for (var i = 0; i < DVGResults.Columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            sw.Write(",");
                        }

                        sw.Write(DVGResults.Columns[i].HeaderText);
                    }

                    sw.WriteLine();

                    for (var r = 0; r < DVGResults.RowCount - 1; r++)
                    {
                        if (r > 0)
                        {
                            sw.WriteLine();
                        }

                        dr = DVGResults.Rows[r];

                        for (var p = 0; p < DVGResults.Columns.Count; p++)
                        {
                            value = dr.Cells[p].Value.ToString();

                            if (value.Length == 0)
                            {
                                value = " ";
                            }

                            if (p != 3)
                            {
                                value = value + ",";
                            }
                            sw.Write(value);

                        }
                    }

                    sw.Close();


                }
            }
        }      
        public void btnClear_Click(object sender, EventArgs e)
        {
            if (DVGResults.Rows.Count != 0)
            {
                DVGResults.Rows.Clear();
                DVGResults.Columns.Clear();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Error: no results to clear", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void btnBrowse_Click(object sender, EventArgs e)
        {
            SVCsvSave.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            SVCsvSave.Filter = "Comma Seperated Value (*.csv)|.csv";
            SVCsvSave.ShowDialog();
        }
    }
}
