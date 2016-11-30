using OLEREO.Control;
using System;
using System.Windows.Forms;

namespace ZIKU.Control.Item
{
    public partial class XiaoChao : Form
    {

        private static  string _xcID = null;
        private static  string _itemID = null;

        private XiaoChao(string xcID,string itemID = null)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ICON;
            _xcID = xcID;
            _itemID = itemID;
        }

        /// <summary>
        /// 打开新建小抄窗口，成功返回小抄ID，否则返回null
        /// </summary>
        /// <param name="itemID">归属项目ID</param>
        public static string addNewXC(string itemID)
        {
            XiaoChao xc = new XiaoChao(null, itemID);
            xc.Text = "新建小抄";
            xc.ShowDialog();
            return _xcID;
        }
        /// <summary>
        /// 打开编辑小抄窗口
        /// </summary>
        /// <param name="xcID">小抄ID</param>
        public static bool editXC(string xcID)
        {
            XiaoChao xc = new XiaoChao(xcID);
            xc.Text = "编辑小抄";
            ZIKU.DataBase.XiaoChao xcSL = ZIKU.DataBase.XiaoChao.getInstance(xcID);
            xc.nameBox.Text = xcSL.name;
            xc.valueBox.text = xcSL.valueShow;
            xc.argumentsBox.text = xcSL.argumentsShow;
            xc.introduceBox.Text = xcSL.introduce;
            xc.searchAliasBox.Text = xcSL.searchAlias;
            xc.copyIntroduce_Box.Checked = xcSL.copyIntroduce;
            xc.ShowDialog();
            if (_xcID == null) return false; else return true;
        }


        private void CancetButton_Click(object sender, System.EventArgs e)
        {
            _xcID = null;         
            this.Close();
        }

        private void SaveButton_Click(object sender, System.EventArgs e)
        {      
            if (!ZIKU.DataBase.XiaoChao.writeXiaoChao(ref _xcID, nameBox.Text, valueBox.text, argumentsBox.text, introduceBox.Text, searchAliasBox.Text, _itemID,copyIntroduce_Box.Checked))
                return;
            this.Close();
        }

        private void valueBox_rButtonClicked(FloatingTextBox THIS, oTextBox oTextBox, EventArgs e)
        {
            THIS.ShowFloating(myZiku.exPand(myZiku.variableToSave(oTextBox.Text, ZIKU.DataBase.Config.Instance.Path), ZIKU.DataBase.Config.Instance.Path));
        }
    }
}
