using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace IPAddressTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            NetWorkList();
            GetNameAndID();
        }

        private ArrayList AryLst = new ArrayList(); // ArrayList 類別
        private ManagementObject objCls; // ManagementObject 類別 , 表示 WMI 執行個體。
        private string strCls = "Win32_NetworkAdapterConfiguration"; // WMI 名稱空間 ( Namespace )
        private string strNS = "root\\CIMV2"; // WMI 類別 (Class)
        private string strIndex; // 用來記錄網路介面卡 Index

        private string projectNum = "";
        private const string robotAdapter = "Intel(R) I211 Gigabit Network Connection";
        private const string ccdAdapter = "Intel(R) Gigabit CT Desktop Adapter";
        private const string ccdAdapter2 = "Intel(R) Gigabit CT Desktop Adapter #2";

        //private const string robotAdapter = "Realtek USB GbE Family Controller";

        private string strIP = "192.168.";
        private string strSubmask = "255.255.255.0";
        private string strGateway = "0.0.0.0";
        private string strDNS1 = "0.0.0.0";
        private string strDNS2 = "0.0.0.0";

        private Dictionary<int, string> adapterDeviceIDwithName = new Dictionary<int, string>();

        private void getAdtInfo()
        {
            comboBox1.Items.Clear();
            AryLst.Clear();
            string strQry = "Select * from Win32_NetworkAdapterConfiguration where IPEnabled=True";
            ManagementObjectSearcher objSc = new ManagementObjectSearcher(strQry);
            foreach (ManagementObject objQry in objSc.Get())
            {
                AryLst.Add(objQry["Index"]); // 將 Index 新增至 ArrayList
                comboBox1.Items.Add(objQry["Description"]); // 將 Description 新增至 ComboBox
            }
        }

        public void SetNetCfg(string strIP, string strSubmask, string strGateway, string strDNS1, string strDNS2, int intAdapterIdx, uint metric)
        {
            var idx = AryLst[intAdapterIdx].ToString();
            // MessageBox.Show("AryLst="+ intAdapterIdx+"--index="+idx);

            objCls = new ManagementObject(strNS, strCls + ".INDEX=" + idx, null);

            ManagementBaseObject objInPara; // 宣告管理物件類別的基本類別

            objInPara = objCls.GetMethodParameters("EnableStatic");

            objInPara["IPAddress"] = new string[] { strIP }; // 設定 "IP" 屬性

            objInPara["SubnetMask"] = new string[] { strSubmask }; // 設定 "子網路遮罩" 屬性

            objCls.InvokeMethod("EnableStatic", objInPara, null);

            objInPara = objCls.GetMethodParameters("SetGateways");

            objInPara["DefaultIPGateway"] = new string[] { strGateway }; // 設定 "Gateway" 屬性

            objCls.InvokeMethod("SetGateways", objInPara, null);

            objInPara = objCls.GetMethodParameters("SetDNSServerSearchOrder");

            objInPara["DNSServerSearchOrder"] = new string[] { strDNS1, strDNS2 }; // 設定 "DNS" 屬性

            objCls.InvokeMethod("SetDNSServerSearchOrder", objInPara, null);

            objInPara = objCls.GetMethodParameters("SetIPConnectionMetric");

            objInPara["IPConnectionMetric"] = metric; // 設定 "介面計量" 屬性

            objCls.InvokeMethod("SetIPConnectionMetric", objInPara, null);
        }

        public void SetAuto()
        {
            // 建立 ManagementObject 物件 ( Scope , Path , options )

            objCls = new ManagementObject(strNS, strCls + ".INDEX=" + strIndex, null);

            // InvokeMethod 方法 : 在物件上叫用方法。

            objCls.InvokeMethod("EnableDHCP", null); // 設定自動取得 IP

            objCls.InvokeMethod("ReleaseDHCPLease", null); // 釋放 IP

            objCls.InvokeMethod("RenewDHCPLease", null); // 重新取得 IP
        }

        public void NetWorkList()
        {
            string manage = "SELECT * From Win32_NetworkAdapter";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(manage);
            ManagementObjectCollection collection = searcher.Get();
            List<string> netWorkList = new List<string>();
            foreach (ManagementObject obj in collection)
            {
                netWorkList.Add(obj["Name"].ToString());
            }
            this.cmbAdapter.DataSource = netWorkList;
        }

        public void GetNameAndID()
        {
            string manage = "SELECT * From Win32_NetworkAdapter";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(manage);
            ManagementObjectCollection collection = searcher.Get();
            foreach (ManagementObject obj in collection)
            {
                adapterDeviceIDwithName.Add(Convert.ToInt32(obj["DeviceID"]), obj["Name"].ToString());
            }
        }

        public bool DisableNetWork(ManagementObject network)
        {
            try
            {
                network.InvokeMethod("Disable", null);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EnableNetWork(ManagementObject network)
        {
            try
            {
                network.InvokeMethod("Enable", null);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool NetWorkState(string netWorkName)
        {
            string netState = "SELECT * From Win32_NetworkAdapter";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(netState);
            ManagementObjectCollection collection = searcher.Get();
            foreach (ManagementObject manage in collection)
            {
                if (manage["Name"].ToString() == netWorkName)
                {
                    return true;
                }
            }
            return false;
        }

        public bool NetWorkState(int deviceID)
        {
            string netState = "SELECT * From Win32_NetworkAdapter";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(netState);
            ManagementObjectCollection collection = searcher.Get();
            foreach (ManagementObject manage in collection)
            {
                if (manage["DeviceID"].ToString() == deviceID.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public ManagementObject NetWork(string networkname)
        {
            string netState = "SELECT * From Win32_NetworkAdapter";

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(netState);
            ManagementObjectCollection collection = searcher.Get();

            foreach (ManagementObject manage in collection)
            {
                if (manage["Name"].ToString() == networkname)
                {
                    return manage;
                }
            }
            return null;
        }

        public ManagementObject NetWork(int deviceID)
        {
            string netState = "SELECT * From Win32_NetworkAdapter";

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(netState);
            ManagementObjectCollection collection = searcher.Get();

            foreach (ManagementObject manage in collection)
            {
                if (manage["DeviceID"].ToString() == deviceID.ToString())
                {
                    return manage;
                }
            }
            return null;
        }

        public void EnableNet(string netName)
        {
            if (NetWorkState(netName))
            {
                if (!EnableNetWork(NetWork(netName)))
                {
                    MessageBox.Show("啟用網路卡 " + netName + " 失敗!");
                }
                else
                {
                    MessageBox.Show("啟用網路卡 " + netName + " 成功!");
                }
            }
            else
            {
                MessageBox.Show("網路卡 " + netName + " 已開啟!");
            }

            NetWorkList();
        }

        public void EnableNet(int deviceID)
        {
            if (NetWorkState(deviceID))
            {
                if (!EnableNetWork(NetWork(deviceID)))
                {
                    MessageBox.Show("啟用網路卡 " + adapterDeviceIDwithName[deviceID] + " 失敗!");
                }
                else
                {
                    MessageBox.Show("啟用網路卡 " + adapterDeviceIDwithName[deviceID] + " 成功!");
                }
            }
            else
            {
                MessageBox.Show("網路卡 " + adapterDeviceIDwithName[deviceID] + " 已開啟!");
            }

            NetWorkList();
        }

        public void DisableNet(string netName)
        {
            if (NetWorkState(netName))
            {
                if (!DisableNetWork(NetWork(netName)))
                {
                    MessageBox.Show("禁用網路卡 " + netName + " 失敗!");
                }
                else
                {
                    MessageBox.Show("禁用網路卡 " + netName + " 成功!");
                }
            }
            else
            {
                MessageBox.Show("網路卡 " + netName + " 已禁用!");
            }

            NetWorkList();
        }

        private string runPowershellScript(string script)// call powershell cmd
        {
            Runspace runSpace = RunspaceFactory.CreateRunspace();
            runSpace.Open();
            Pipeline pipeline = runSpace.CreatePipeline();
            pipeline.Commands.AddScript(script);
            pipeline.Commands.Add("Out-String");
            Collection<PSObject> results = pipeline.Invoke();
            runSpace.Close();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject pSObject in results)
            {
                stringBuilder.AppendLine(pSObject.ToString());
            }
            return stringBuilder.ToString();
        }

        private void renameAdapter(string interfaceDescription, string newID)
        {
            var originalID = getAdapterName(interfaceDescription);
            MessageBox.Show("更改名稱:" + originalID + " --> " + newID);
            runPowershellScript("Rename-NetAdapter -Name \"" + originalID + "\" -NewName \"" + newID + "\"");
        }

        private string getAdapterName(string interfaceDescription)
        {
            return runPowershellScript("Get-NetAdapter -InterfaceDescription \"" + interfaceDescription + "\"|Format-list -Property Name").Trim().Replace("Name : ", "");
        }

        #region UI event

        private void Form1_Load(object sender, EventArgs e)
        {
            getAdtInfo();
            nicQty.Text = "已連線的網路卡數量: " + comboBox1.Items.Count.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            strIndex = (AryLst[comboBox1.SelectedIndex]).ToString();
        }

        private void settingIP_Click(object sender, EventArgs e)
        {
            var intRobotIndex = comboBox1.Items.IndexOf(robotAdapter);
            var intCCDIndex = comboBox1.Items.IndexOf(ccdAdapter);
            var intCCDIndex2 = comboBox1.Items.IndexOf(ccdAdapter2);

            DialogResult dialogResult = MessageBox.Show("是否進行IP自動配置?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                if (intRobotIndex != -1)
                {
                    SetNetCfg(strIP + "137." + projectNum, strSubmask, strGateway, strDNS1, strDNS2, intRobotIndex, 1500);
                    DisableNet(robotAdapter);
                    Thread.Sleep(500);
                    EnableNet(robotAdapter);
                    renameAdapter(robotAdapter, "Robot");
                    Thread.Sleep(500);
                }

                if (intCCDIndex != -1)
                {
                    SetNetCfg(strIP + "138." + projectNum, strSubmask, strGateway, strDNS1, strDNS2, intCCDIndex, 1000);
                    DisableNet(ccdAdapter);
                    Thread.Sleep(500);
                    EnableNet(ccdAdapter);
                    renameAdapter(ccdAdapter, "CCD");
                }
                else if (intCCDIndex2 != -1)
                {
                    int CCD2DeviceID = -1;
                    SetNetCfg(strIP + "138." + projectNum, strSubmask, strGateway, strDNS1, strDNS2, intCCDIndex2, 1000);
                    DisableNet(ccdAdapter2);
                    Thread.Sleep(500);
                    foreach (KeyValuePair<int, string> data in adapterDeviceIDwithName)
                    {
                        if (data.Value == ccdAdapter2)
                        { CCD2DeviceID = data.Key; }
                    }
                    /*win32_wmiObject 抓取的網路卡是#2那張 被disable後 名稱會跟ccd重複，所以用ID去設定
                    ps:Get-WmiObject -Class Win32_NetworkAdapter |Format-List -Property "Name"*/
                    EnableNet(CCD2DeviceID);
                    renameAdapter(ccdAdapter2, "CCD1");
                }
            }
        }

        private void settingDHCP_Click(object sender, EventArgs e)
        {
            SetAuto(); // 呼叫 SetAuto 程序 , 設定網路介面卡組態
        }

        private void projectNumeric_ValueChanged(object sender, EventArgs e)
        {
            projectNum = projectNumeric.Value.ToString();
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            EnableNet(this.cmbAdapter.SelectedValue.ToString());
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            DisableNet(this.cmbAdapter.SelectedValue.ToString());
        }

        private void btnOpenSetting_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ncpa.cpl");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getAdtInfo();
            nicQty.Text = "已連線的網路卡數量: " + comboBox1.Items.Count.ToString();
            NetWorkList();
        }

        #endregion UI event
    }
}