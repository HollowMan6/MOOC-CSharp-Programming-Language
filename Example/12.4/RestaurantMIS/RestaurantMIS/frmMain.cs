using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RestaurantMIS.Model;
using System.Drawing.Printing;

namespace RestaurantMIS
{
    public partial class frmMain : Form
    {
        #region Members

        public BLL.Buy bllbuy = new RestaurantMIS.BLL.Buy();
        public BLL.Income bllincome = new RestaurantMIS.BLL.Income();
        public BLL.Wine bllwine = new RestaurantMIS.BLL.Wine();
        public BLL.Cigarette bllcigarette = new RestaurantMIS.BLL.Cigarette();
        public BLL.CaiDan bllcaidan = new RestaurantMIS.BLL.CaiDan();
        DataGridViewPrinter MyDataGridViewPrinter;

        #endregion

        public frmMain()
        {
            InitializeComponent();
            BindBuyHistory();
            BindIncomeHistory();
            BindWineHistory();
            BindCigaretteHistory();
            cb1Category.SelectedIndex = 1;
            BindDDL();
            CheckPayDate();
            BindCaidans();
        }

        #region 进货记录

        private void btn1Search_Click(object sender, EventArgs e)
        {
            StringBuilder swhere = new StringBuilder();
            if (cb1SaleSearch.Text != string.Empty)
            {
                swhere.Append(" Saler='" + cb1SaleSearch.Text + "' And");
            }
            swhere.Append(" LogDate >= #" + dp1BeginDate.Value.Date.ToShortDateString() + "# And LogDate<#" + dp1EndDate.Value.Date.AddDays(1).ToShortDateString()+"#");
            
            BindBuyHistory(swhere.ToString());
        }

        /// <summary>
        /// 进货记录保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1Save_Click(object sender, EventArgs e)
        {
            if (ValidateAddBuy())
            {
                Buy model = new Buy()
                {
                    Category = this.cb1Category.Text.Trim(),
                    LogDate = this.dp1Date.Value.Date,
                    Memo = string.Empty,
                    Money = Convert.ToDecimal(this.tb1Money.Text),
                    Num = Convert.ToDecimal(this.tb1Num.Text),
                    Saler = this.cb1Saler.Text.Trim(),
                    Product = this.cb1Product.Text.Trim(),
                    Type = this.cb1Type.Text.Trim(),
                    Price = Convert.ToDecimal(this.tb1Price.Text.Trim()),
                    Unit = this.cb1Unit.Text.Trim()
                };

                try
                {
                    bllbuy.Add(model);
                    MessageBox.Show("添加成功！");
                    this.BindBuyHistory();

                    foreach (Control cb in this.tpBuy.Controls[1].Controls)
                    {
                        if (cb is ComboBox || cb is TextBox)
                        {
                            cb.Text = string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// 验证待添加的进货记录输入
        /// </summary>
        /// <returns></returns>
        private bool ValidateAddBuy()
        {
            float test;
            foreach (Control cb in this.tpBuy.Controls[1].Controls)
            {
                if (cb is ComboBox)
                {
                    if ((cb as ComboBox).Text == string.Empty)
                    {
                        MessageBox.Show("请先将内容填写完整");
                        return false;
                    }
                }
                if (cb is TextBox)
                {
                    if ((cb as TextBox).Text == string.Empty)
                    {
                        MessageBox.Show("请先将内容填写完整");
                        return false;
                    }
                    if (!float.TryParse((cb as TextBox).Text, out test))
                    {
                        MessageBox.Show("请输入数字");
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 绑定进货记录列表
        /// </summary>
        private void BindBuyHistory()
        {
            BindBuyHistory(string.Empty);
        }

        /// <summary>
        /// 绑定进货记录列表
        /// </summary>
        private void BindBuyHistory(string where)
        {
            DataTable dt = bllbuy.GetList(where).Tables[0];
            dt.Columns["ID"].ColumnName = "编号";
            dt.Columns["Saler"].ColumnName = "供应商";
            dt.Columns["Product"].ColumnName = "品名";
            dt.Columns["Type"].ColumnName = "规格";
            dt.Columns["Price"].ColumnName = "单价";
            dt.Columns["Unit"].ColumnName = "单位";
            dt.Columns["Num"].ColumnName = "数量";
            dt.Columns["Money"].ColumnName = "金额";
            dt.Columns["Category"].ColumnName = "类型";
            dt.Columns["LogDate"].ColumnName = "日期";
            dt.Columns["Memo"].ColumnName = "备注";

            this.dgv1Buy.DataSource = dt;
        }

        /// <summary>
        /// 设置打印内容
        /// </summary>
        /// <param name="MyDataGridView"></param>
        /// <returns></returns>
        private bool SetupThePrinting(string title, DataGridView MyDataGridView)
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            MyPrintDocument.DocumentName = title;
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView, MyPrintDocument, true, true, title, new Font("微软雅黑", 25, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        /// <summary>
        /// 打印文件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        /// <summary>
        /// 删除进货记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1Delete_Click(object sender, EventArgs e)
        {
            if (this.dgv1Buy.SelectedRows[0].Cells[0].Value != null)
            {
                if (MessageBox.Show("您确认要删除这条记录吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    int id = Convert.ToInt32(this.dgv1Buy.SelectedRows[0].Cells[0].Value.ToString());
                    var mod = bllbuy.GetModel(id);
                    bllbuy.Delete(id);
                    MessageBox.Show("删除成功！");

                    this.BindBuyHistory();
                }
            }
            else
            {
                MessageBox.Show("请先选中要删除的行");
            }
        }

        /// <summary>
        /// 打印进货历史记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1Print_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting("进货记录报表", this.dgv1Buy))
                MyPrintDocument.Print();
        }

        /// <summary>
        /// 绑定输入历史
        /// </summary>
        private void BindDDL()
        {
            BindDDLTab1(cb1Category.SelectedText);

            List<string> historySalers = bllbuy.GetDistinctCol("Saler");
            cb2Saler.Items.AddRange(historySalers.ToArray());
            cb2SalerSearch.Items.AddRange(historySalers.ToArray());

            List<string> historyNames = bllwine.GetDistinctCol("Name");
            cb4Name.Items.AddRange(historyNames.ToArray());
            cb4SearchName.Items.AddRange(historyNames.ToArray());

            List<string> historyWineTypes = bllwine.GetDistinctCol("Type");
            cb4Type.Items.AddRange(historyWineTypes.ToArray());

            List<string> historyWineUnits = bllwine.GetDistinctCol("Unit");
            cb4Unit.Items.AddRange(historyWineUnits.ToArray());

            List<string> historyCigaretteNames = bllcigarette.GetDistinctCol("Name");
            cb5Name.Items.AddRange(historyCigaretteNames.ToArray());
            cb5SearchName.Items.AddRange(historyCigaretteNames.ToArray());

            List<string> historyCigaretteTypes = bllcigarette.GetDistinctCol("Type");
            cb5Type.Items.AddRange(historyCigaretteTypes.ToArray());

            List<string> historyCigaretteUnits = bllcigarette.GetDistinctCol("Unit");
            cb5Unit.Items.AddRange(historyCigaretteUnits.ToArray());

            List<string> historycategorys = bllcaidan.GetDistinctCol("Category");
            cb7Category.Items.AddRange(historycategorys.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TypeName"></param>
        private void BindDDLTab1(string TypeName)
        {
            List<string> historySalers = bllbuy.GetDistinctCol("Saler", TypeName);
            cb1Saler.Items.Clear();
            cb1Saler.Items.AddRange(historySalers.ToArray());
            cb1SaleSearch.Items.AddRange(historySalers.ToArray());

            List<string> historyProducts = bllbuy.GetDistinctCol("Product", TypeName);
            cb1Product.Items.Clear();
            cb1Product.Items.AddRange(historyProducts.ToArray());

            List<string> historyTypes = bllbuy.GetDistinctCol("Type", TypeName);
            cb1Type.Items.Clear();
            cb1Type.Items.AddRange(historyTypes.ToArray());

            List<string> historyUnits = bllbuy.GetDistinctCol("Unit", TypeName);
            cb1Unit.Items.Clear();
            cb1Unit.Items.AddRange(historyUnits.ToArray());
        }

        /// <summary>
        /// 计算金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb1Num_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(tb1Price.Text.Trim() == string.Empty) && !(tb1Num.Text.Trim() == string.Empty))
                {
                    tb1Money.Text = Convert.ToString(Convert.ToDecimal(tb1Price.Text) * Convert.ToDecimal(tb1Num.Text));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请输入数字");
            }
        }

        private void cb1Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDDLTab1(cb1Category.Text);
        }

        #endregion

        #region 进货支出汇总

        /// <summary>
        /// 查询进货支出汇总
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn2Seach_Click(object sender, EventArgs e)
        {
            List<PaySum> totallist = new List<PaySum>();

            if (cb2SalerSearch.Text.Trim() != string.Empty)
            {
                totallist = CalculatePaySum(cb2SalerSearch.Text.Trim(), dp2BeginDate.Value.Date, dp2EndDate.Value.Date.AddDays(1));
            }
            else
            {
                foreach (string saler in bllbuy.GetDistinctCol("Saler"))
                {
                    totallist.AddRange(CalculatePaySum(saler,dp2BeginDate.Value.Date, dp2EndDate.Value.Date.AddDays(1)));
                }
            }

            this.dgv2PaySum.DataSource = totallist;
        }

        /// <summary>
        /// 计算某供货商某段时间内的金额汇总
        /// </summary>
        /// <param name="saler"></param>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        private List<PaySum> CalculatePaySum(string saler, DateTime dt1, DateTime dt2)
        {
            StringBuilder swhere = new StringBuilder();
            swhere.Append("HasPaid=false AND");
            swhere.Append(" Saler='" + saler + "'");

            List<Buy> listbuy = bllbuy.GetModelList(swhere.ToString());
            List<PaySum> listsum = new List<PaySum>();

            DateTime temp = dt1;
            for (; temp < dt2; temp = temp.AddDays(1))
            {
                PaySum mod = new PaySum()
                {
                    日期 = temp,
                    供货商 = saler,
                    当日金额 = listbuy.Where(o => o.LogDate == temp && o.Saler == saler).Sum(o => o.Money),
                    承上天金额 = listbuy.Where(o => o.LogDate < temp && o.Saler == saler).Sum(o => o.Money),
                    累计金额 = listbuy.Where(o => o.LogDate <= temp && o.Saler == saler).Sum(o => o.Money)
                };
                if (mod.累计金额 == 0)
                    continue;
                listsum.Add(mod);
            }
            return listsum;
        }

        /// <summary>
        /// 打印进货支出汇总
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn2Print_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting("进货支出汇总", this.dgv2PaySum))
                MyPrintDocument.Print();
        }

        /// <summary>
        /// 双击汇总记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv2PaySum_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgv2PaySum.SelectedRows.Count>0)
            {
                string saler =this.dgv2PaySum.SelectedRows[0].Cells[0].Value.ToString();
                DateTime day = Convert.ToDateTime(this.dgv2PaySum.SelectedRows[0].Cells[4].Value.ToString());

                this.cb1SaleSearch.Text = saler;
                this.dp1BeginDate.Value = day;
                this.dp1EndDate.Value = day;

                this.btn1Search_Click(sender,e);
                this.tabMain.SelectedTab = tpBuy;
            }
        }

        /// <summary>
        /// 结账
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn2Pay_Click(object sender, EventArgs e)
        {
            if (this.cb2Saler.Text == string.Empty)
            {
                MessageBox.Show("请先选择供货商");
                return;
            }

            string saler = this.cb2Saler.Text.Trim();
            string dt = this.dp2Before.Value.Date.AddDays(1).ToShortDateString();

            if (MessageBox.Show("您确认要将" + saler + "在"+dt+"之前的账务都结了吗？", "结账确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bllbuy.Pay(saler, dt);
                    MessageBox.Show("结账成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("系统错误，结账失败，请稍后重试\r\n\r" + ex.Message);
                }
            }

        }

        /// <summary>
        /// 结账提醒
        /// </summary>
        private void CheckPayDate()
        {
            if (DateTime.Today.Day == 1)
            {
                MessageBox.Show("今天是一号，请不要忘记结账");
            }
        }

        #endregion

        #region 入库报表

        private void btn6Search_Click(object sender, EventArgs e)
        {
            dgv6Report.DataSource = CalculateRuku(dp6From.Value.Date, dp6To.Value.Date.AddDays(1));
        }

        private List<Ruku> CalculateRuku(DateTime dt1, DateTime dt2)
        {
            List<Buy> listbuy = bllbuy.GetModelList(string.Empty);
            List<Ruku> listsum = new List<Ruku>();

            DateTime temp = dt1;
            for (; temp < dt2; temp = temp.AddDays(1))
            {
                Ruku mod = new Ruku()
                {
                    日期 = temp,
                    厨房入库=  listbuy.Where(o => o.Category == "厨房入库" && o.LogDate == temp).Sum(o => o.Money),
                    酒水入库 = listbuy.Where(o => o.Category == "酒水入库" && o.LogDate == temp).Sum(o => o.Money),
                    香烟入库 = listbuy.Where(o => o.Category == "香烟入库" && o.LogDate == temp).Sum(o => o.Money),
                    干货入库 = listbuy.Where(o => o.Category == "干货入库" && o.LogDate == temp).Sum(o => o.Money),
                    食油入库 = listbuy.Where(o => o.Category == "食油入库" && o.LogDate == temp).Sum(o => o.Money),
                    合计金额 = listbuy.Where(o =>o.LogDate == temp).Sum(o => o.Money)
                };
                listsum.Add(mod);
            }
            return listsum;
        }

        private void btn6Print_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting("入库报表", this.dgv6Report))
                MyPrintDocument.Print();
        }

        #endregion

        #region 日结算表

        private void btn3Save_Click(object sender, EventArgs e)
        {
            if (!ValidateAddIncome())
                return;

            Income mod = new Income()
            {
                DishMoney = Convert.ToDecimal(tb3Cai.Text),
                WineMoney = Convert.ToDecimal(tb3Jiu.Text),
                LogDate = dp3.Value.Date,
                OtherMoney = Convert.ToDecimal(tb3Qita.Text),
                IncomeLendSum = Convert.ToDecimal(tb3Lend.Text),
                ReturnSum = Convert.ToDecimal(tb3Huishou.Text)
            };

            mod.IncomeMoneySum = mod.DishMoney + mod.WineMoney + mod.OtherMoney;
            mod.IncomeSum = mod.IncomeMoneySum + mod.IncomeLendSum;
            mod.Memo = string.Empty;

            try
            {
                bllincome.Add(mod);
                MessageBox.Show("添加成功！");
                this.BindIncomeHistory();

                foreach (Control cb in this.tpIncome.Controls[1].Controls)
                {
                    if (cb is ComboBox || cb is TextBox)
                    {
                        cb.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindIncomeHistory()
        {
            BindIncomeHistory(string.Empty);
        }

        private void BindIncomeHistory(string where)
        {
            DataTable dt = bllincome.GetList(where).Tables[0];
            dt.Columns["ID"].ColumnName = "编号";
            dt.Columns["DishMoney"].ColumnName = "菜肴现金收入";
            dt.Columns["WineMoney"].ColumnName = "酒水现金收入";
            dt.Columns["OtherMoney"].ColumnName = "其它现金收入";
            dt.Columns["IncomeLendSum"].ColumnName = "签单收入";
            dt.Columns["ReturnSum"].ColumnName = "收回欠款";
            dt.Columns["IncomeMoneySum"].ColumnName = "总现金收入";
            dt.Columns["IncomeSum"].ColumnName = "当日总收入";
            dt.Columns["LogDate"].ColumnName = "日期";
            dt.Columns["Memo"].ColumnName = "备注";

            this.dgv3Report.DataSource = dt;
        }

        /// <summary>
        /// 验证待添加的进货记录输入
        /// </summary>
        /// <returns></returns>
        private bool ValidateAddIncome()
        {
            float test;
            foreach (Control cb in this.tpIncome.Controls[1].Controls)
            {
                if (cb is TextBox)
                {
                    if ((cb as TextBox).Text == string.Empty)
                    {
                        MessageBox.Show("请先将内容填写完整");
                        return false;
                    }
                    if (!float.TryParse((cb as TextBox).Text, out test))
                    {
                        MessageBox.Show("请输入数字");
                        return false;
                    }
                }
            }
            return true;
        }

        private void btn3Print_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting("日结算表", this.dgv3Report))
                MyPrintDocument.Print();
        }

        private void btn3Search_Click(object sender, EventArgs e)
        {
            StringBuilder swhere = new StringBuilder();
            swhere.Append(" LogDate >= #" + dp3From.Value.Date.ToShortDateString() + "# And LogDate<#" + dp3To.Value.Date.AddDays(1).ToShortDateString() + "#");
            BindIncomeHistory(swhere.ToString());
        }

        private void btn3Delete_Click(object sender, EventArgs e)
        {
            if (this.dgv3Report.SelectedRows[0].Cells[0].Value != null)
            {
                if (MessageBox.Show("您确认要删除这条记录吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    int id = Convert.ToInt32(this.dgv3Report.SelectedRows[0].Cells[0].Value.ToString());
                    var mod = bllincome.GetModel(id);
                    bllincome.Delete(id);
                    MessageBox.Show("删除成功！");

                    this.BindIncomeHistory();
                }
            }
            else
            {
                MessageBox.Show("请先选中要删除的行");
            }
        }

        #endregion

        #region 酒水日报表

        /// <summary>
        /// 验证待添加的进货记录输入
        /// </summary>
        /// <returns></returns>
        private bool ValidateAddWine()
        {
            float test;
            foreach (Control cb in this.tpWine.Controls[0].Controls)
            {
                if (cb is ComboBox)
                {
                    if ((cb as ComboBox).Text == string.Empty)
                    {
                        MessageBox.Show("请先将内容填写完整");
                        return false;
                    }
                }
                if (cb is TextBox)
                {
                    if (cb.Name == "tb4Memo")
                        continue;
                    if ((cb as TextBox).Text == string.Empty)
                    {
                        MessageBox.Show("请先将内容填写完整");
                        return false;
                    }
                    if (!float.TryParse((cb as TextBox).Text, out test))
                    {
                        MessageBox.Show("请输入数字");
                        return false;
                    }
                }
            }
            return true;
        }
        
        private void btn4Save_Click(object sender, EventArgs e)
        {
            if (ValidateAddWine())
            {
                Wine model = new Wine()
                {
                    Name = this.cb4Name.Text.Trim(),
                    Type = this.cb4Type.Text.Trim(),
                    Unit = this.cb4Unit.Text.Trim(),
                    Memo = this.tb4Memo.Text.Trim(),
                    Price = Convert.ToDecimal(this.tb4Price.Text.Trim()),
                    TodayInNum = Convert.ToInt32(this.tb4TodayIn.Text.Trim()),
                    TodayOutNum = Convert.ToInt32(this.tb4TodayOut.Text),
                    TodayStorkNum = Convert.ToInt32(this.tb4TodayStork.Text),
                    YesterdayStorkNum = Convert.ToInt32(this.tb4YesterdayStork.Text),
                    IncomeSum = Convert.ToDecimal(this.tb4IncomeSum.Text),
                    LogDate = this.dp4.Value.Date
                };

                try
                {
                    bllwine.Add(model);
                    MessageBox.Show("添加成功！");
                    this.BindWineHistory();

                    foreach (Control cb in this.tpWine.Controls[0].Controls)
                    {
                        if (cb is ComboBox || cb is TextBox)
                        {
                            cb.Text = string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BindWineHistory()
        {
            BindWineHistory(string.Empty);
        }

        private void BindWineHistory(string where)
        {
            DataTable dt = bllwine.GetList(where).Tables[0];
            dt.Columns["ID"].ColumnName = "编号";
            dt.Columns["Name"].ColumnName = "品名";
            dt.Columns["Type"].ColumnName = "规格";
            dt.Columns["Unit"].ColumnName = "单位";
            dt.Columns["YesterdayStorkNum"].ColumnName = "昨日库存";
            dt.Columns["TodayInNum"].ColumnName = "今日进货";
            dt.Columns["TodayOutNum"].ColumnName = "售出数量";
            dt.Columns["TodayStorkNum"].ColumnName = "今日库存";
            dt.Columns["Price"].ColumnName = "单价";
            dt.Columns["IncomeSum"].ColumnName = "售出金额";
            dt.Columns["LogDate"].ColumnName = "日期";
            dt.Columns["Memo"].ColumnName = "备注";

            this.dgv4Report.DataSource = dt;
        }

        private void btn4Search_Click(object sender, EventArgs e)
        {
            StringBuilder swhere = new StringBuilder();
            if (cb4SearchName.Text != string.Empty)
            {
                swhere.Append(" Name='" + cb4SearchName.Text + "' And");
            }
            swhere.Append(" LogDate >= #" + dp4From.Value.Date.ToShortDateString() + "# And LogDate<#" + dp4To.Value.Date.AddDays(1).ToShortDateString() + "#");

            BindWineHistory(swhere.ToString());
        }

        private void tbn4Print_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting("酒水日报表", this.dgv4Report))
                MyPrintDocument.Print();
        }

        private void btn4Delete_Click(object sender, EventArgs e)
        {
            if (this.dgv4Report.SelectedRows[0].Cells[0].Value != null)
            {
                if (MessageBox.Show("您确认要删除这条记录吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    int id = Convert.ToInt32(this.dgv4Report.SelectedRows[0].Cells[0].Value.ToString());
                    var mod =bllwine.GetModel(id);
                    bllwine.Delete(id);
                    MessageBox.Show("删除成功！");

                    this.BindWineHistory();
                }
            }
            else
            {
                MessageBox.Show("请先选中要删除的行");
            }
        }

        private void tb4TodayOut_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(tb4TodayIn.Text.Trim() == string.Empty) && !(tb4TodayOut.Text.Trim() == string.Empty) && !(tb4YesterdayStork.Text.Trim() == string.Empty))
                {
                    tb4TodayStork.Text = Convert.ToString(Convert.ToDecimal(tb4TodayIn.Text) + Convert.ToDecimal(tb4YesterdayStork.Text) - Convert.ToDecimal(tb4TodayOut.Text));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请输入数字");
            }
        }

        private void cb4Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb4YesterdayStork.Text = bllwine.GetYesterdayStork(dp4.Value.Date, cb4Name.Text.ToString());
        }

        #endregion

        #region 香烟日报表

        /// <summary>
        /// 验证待添加的进货记录输入
        /// </summary>
        /// <returns></returns>
        private bool ValidateAddCigarette()
        {
            float test;
            foreach (Control cb in this.tpCigarette.Controls[1].Controls)
            {
                if (cb is ComboBox)
                {
                    if ((cb as ComboBox).Text == string.Empty)
                    {
                        MessageBox.Show("请先将内容填写完整");
                        return false;
                    }
                }
                if (cb is TextBox)
                {
                    if (cb.Name == "tb5Memo")
                        continue;
                    if ((cb as TextBox).Text == string.Empty)
                    {
                        MessageBox.Show("请先将内容填写完整");
                        return false;
                    }
                    if (!float.TryParse((cb as TextBox).Text, out test))
                    {
                        MessageBox.Show("请输入数字");
                        return false;
                    }
                }
            }
            return true;
        }

        private void btn5Save_Click(object sender, EventArgs e)
        {
            if (ValidateAddCigarette())
            {
                Cigarette model = new Cigarette()
                {
                    Name = this.cb5Name.Text.Trim(),
                    Type = this.cb5Type.Text.Trim(),
                    Unit = this.cb5Unit.Text.Trim(),
                    Memo = this.tb5Memo.Text.Trim(),
                    Price = Convert.ToDecimal(this.tb5Price.Text.Trim()),
                    TodayInNum = Convert.ToInt32(this.tb5TodayIn.Text.Trim()),
                    TodayOutNum = Convert.ToInt32(this.tb5TodayOut.Text),
                    TodayStorkNum = Convert.ToInt32(this.tb5TodayStork.Text),
                    YesterdayStorkNum = Convert.ToInt32(this.tb5YesterdayStork.Text),
                    IncomeSum = Convert.ToDecimal(this.tb5IncomeSum.Text),
                    LogDate = this.dp5.Value.Date
                };

                try
                {
                    bllcigarette.Add(model);
                    MessageBox.Show("添加成功！");
                    this.BindCigaretteHistory();

                    foreach (Control cb in this.tpCigarette.Controls[1].Controls)
                    {
                        if (cb is ComboBox || cb is TextBox)
                        {
                            cb.Text = string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BindCigaretteHistory()
        {
            BindCigaretteHistory(string.Empty);
        }

        private void BindCigaretteHistory(string where)
        {
            DataTable dt = bllcigarette.GetList(where).Tables[0];
            dt.Columns["ID"].ColumnName = "编号";
            dt.Columns["Name"].ColumnName = "品名";
            dt.Columns["Type"].ColumnName = "规格";
            dt.Columns["Unit"].ColumnName = "单位";
            dt.Columns["YesterdayStorkNum"].ColumnName = "昨日库存";
            dt.Columns["TodayInNum"].ColumnName = "今日进货";
            dt.Columns["TodayOutNum"].ColumnName = "售出数量";
            dt.Columns["TodayStorkNum"].ColumnName = "今日库存";
            dt.Columns["Price"].ColumnName = "单价";
            dt.Columns["IncomeSum"].ColumnName = "售出金额";
            dt.Columns["LogDate"].ColumnName = "日期";
            dt.Columns["Memo"].ColumnName = "备注";

            this.dgv5Report.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            StringBuilder swhere = new StringBuilder();
            if (cb5SearchName.Text != string.Empty)
            {
                swhere.Append(" Name='" + cb5SearchName.Text + "' And");
            }
            swhere.Append(" LogDate >= #" + dp5From.Value.Date.ToShortDateString() + "# And LogDate<#" + dp5To.Value.Date.AddDays(1).ToShortDateString() + "#");

            BindCigaretteHistory(swhere.ToString());
        }

        private void btn5Print_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting("香烟日报表", this.dgv5Report))
                MyPrintDocument.Print();
        }

        private void btn5Delete_Click(object sender, EventArgs e)
        {
            if (this.dgv5Report.SelectedRows[0].Cells[0].Value != null)
            {
                if (MessageBox.Show("您确认要删除这条记录吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    int id = Convert.ToInt32(this.dgv5Report.SelectedRows[0].Cells[0].Value.ToString());
                    var mod = bllcigarette.GetModel(id);
                    bllcigarette.Delete(id);
                    MessageBox.Show("删除成功！");

                    this.BindCigaretteHistory();
                }
            }
            else
            {
                MessageBox.Show("请先选中要删除的行");
            }
        }

        private void cb5Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb5YesterdayStork.Text = bllcigarette.GetYesterdayStork(dp5.Value.Date, cb5Name.Text.ToString());
        }

        private void tb5TodayOut_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(tb5TodayIn.Text.Trim() == string.Empty) && !(tb5TodayOut.Text.Trim() == string.Empty) && !(tb5YesterdayStork.Text.Trim() == string.Empty))
                {
                    tb5TodayStork.Text = Convert.ToString(Convert.ToDecimal(tb5TodayIn.Text) + Convert.ToDecimal(tb5YesterdayStork.Text) - Convert.ToDecimal(tb5TodayOut.Text));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请输入数字");
            }
        }

        #endregion

        #region 菜单管理

        private void BindCaidans()
        {
            DataTable dt = bllcaidan.GetAllList().Tables[0];

            dt.Columns["ID"].ColumnName = "编号";
            dt.Columns["Name"].ColumnName = "菜名";
            dt.Columns["Category"].ColumnName = "类别";
            dt.Columns["Price"].ColumnName = "价格";
            dt.Columns["LogDate"].ColumnName = "更新时间";

            this.dgv7Caidans.DataSource = dt;
        }

        private void btn7Save_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(lbl7No.Text,out id))
            {
                MessageBox.Show("请在列表中选中需要修改的记录行！");
                return;
            }
            if (cb7Category.Text == string.Empty)
            {
                MessageBox.Show("请输入分类！");
                return;
            }
            if (tb7Name.Text == string.Empty)
            {
                MessageBox.Show("请输入名称！");
                return;
            }
            float price;
            if (!float.TryParse(tb7Price.Text, out price))
            {
                MessageBox.Show("请输入价钱,并请以数字格式输入，保证格式正确!");
                return;
            }

            CaiDan mod = new CaiDan()
            {
                ID = id,
                Category = cb7Category.Text,
                Name = tb7Name.Text,
                Price = Convert.ToDecimal(price),
                LogDate = DateTime.Now
            };

            try
            {
                bllcaidan.Update(mod);
                MessageBox.Show("修改成功！");
                BindCaidans();
                lbl7No.Text = string.Empty;
                cb7Category.Text = string.Empty;
                tb7Name.Text = string.Empty;
                tb7Price.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败，错误信息为：" + ex.Message);
            }
        }

        private void btn7Add_Click(object sender, EventArgs e)
        {
            if (cb7Category.Text == string.Empty)
            {
                MessageBox.Show("请输入分类！");
                return;
            }
            if(tb7Name.Text == string.Empty)
            {
                MessageBox.Show("请输入名称1");
                return;
            }
            float price;
            if (!float.TryParse(tb7Price.Text, out price))
            {
                MessageBox.Show("请输入价钱,并请以数字格式输入，保证格式正确!");
                return;
            }

            CaiDan mod = new CaiDan()
            {
                Category = cb7Category.Text,
                Name = tb7Name.Text,
                Price = Convert.ToDecimal(price),
                LogDate = DateTime.Now
            };

            try
            {
                bllcaidan.Add(mod);
                MessageBox.Show("添加成功！");
                BindCaidans();
                lbl7No.Text = string.Empty;
                cb7Category.Text = string.Empty;
                tb7Name.Text = string.Empty;
                tb7Price.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加失败，错误信息为：" + ex.Message);
            }
        }

        private void btn7Delete_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(lbl7No.Text, out id))
            {
                MessageBox.Show("请在列表中选中需要删除的记录行！");
                return;
            }
            try
            {
                if (MessageBox.Show("您确认要删除这条记录吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bllcaidan.Delete(id);
                    MessageBox.Show("删除成功！");

                    this.BindCaidans();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败，错误信息为：" + ex.Message);
            }
        }

        private void dgv7Caidans_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv7Caidans.SelectedRows.Count == 0)
                return;

            lbl7No.Text = this.dgv7Caidans.SelectedRows[0].Cells[0].Value.ToString();
            cb7Category.Text = this.dgv7Caidans.SelectedRows[0].Cells[1].Value.ToString();
            tb7Name.Text = this.dgv7Caidans.SelectedRows[0].Cells[2].Value.ToString();
            tb7Price.Text = this.dgv7Caidans.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void btn7Clear_Click(object sender, EventArgs e)
        {
            lbl7No.Text = "0";
            cb7Category.Text = string.Empty;
            tb7Name.Text = string.Empty;
            tb7Price.Text = string.Empty;
        }

        #endregion

    }
}
