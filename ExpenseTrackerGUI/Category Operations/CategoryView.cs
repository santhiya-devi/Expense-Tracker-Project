using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpenseTrackerDS;
using ExpenseTracker;

namespace ExpenseTrackerGUI
{
    public partial class CategoryView : UserControl
    {
        public CategoryView()
        {
            InitializeComponent();

            data = new List<Category>();
            if(!this.DesignMode) data = Communicator.Manager.FetchCategories();

            expenseTrees = new List<TreeControl>();
            incomeTrees = new List<TreeControl>();
            modifyCategory = new ModifyCategory();
            this.Controls.Add(modifyCategory);
            modifyCategory.Hide();
            modifyCategory.VisibleChanged += OnModifyCategoryVisibilityChanged;
            modifyCategory.CategoryChange += OnCategoryChanged;
            modifyCategory.CategoryClose += OnCategoryClosed;
            modifyCategory.WalletChange += OnWalletChanged;

            wallet = new Wallet();
            
            pnlExpenseCategory.Hide();
            GetTreeControls(true);
            GetTreeControls(false);
            pnlExpense.Show();

            inactiveIncomeCategory = new List<BranchControl>();
            inactiveExpenseCategory = new List<BranchControl>();

            GUIStyles.ColorChanged += OnColorChanged;


            typeof(Panel).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, pnlExpenseCategory, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, pnlIncomeCategory, new object[] { true });
        }

        private bool categoryType = false, editMode= false, addMode=false, modifyCategoryVisibility=false;
        private string searchText = "";
        private int borderWidth = 12;
        private Wallet wallet;
        private List<TreeControl> incomeTrees;
        private List<TreeControl> expenseTrees;
        private List<BranchControl> inactiveIncomeCategory;
        private List<BranchControl> inactiveExpenseCategory;

        private List<Category> data;
        private ModifyCategory modifyCategory;

        private EditCategoryShow editCategory = EditCategoryShow.Both;

        public event EventHandler<Category> CategorySelect;

        public event EventHandler CategoryClose;
        public event EventHandler SearchBar;

        #region Properties
        
        public bool EditMode
        {
            get => editMode;
            set => editMode = value;
        }

        public int BorderWidth
        {
            get => borderWidth;
            set
            {
                borderWidth = value;
                pnlTop.Height = pnlBottom.Height = pnlRight.Width = pnlLeft.Width = borderWidth;
            }
        }

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                if (searchText.Length > 0)
                {
                    OnSeachBarTextChanged(this, searchText);
                }
                else
                {
                    OnSearchBackClicked(this, EventArgs.Empty);
                }
            }
        }

        public Wallet Wallet
        {
            get => wallet;
            set
            {
                wallet = value;
            }
        }

        public Wallet WalletChange
        {
            get => Wallet;
            set
            {
                Wallet = value;
                this.SuspendLayout();
                ShowCategory(true, Wallet);
                ShowCategory(false, Wallet);
                this.ResumeLayout();
            }
        }
        
        public bool ModifyCategoryVisibility
        {
            get => modifyCategoryVisibility;
            set
            {
                modifyCategoryVisibility = value;
            }
        }
        
        public EditCategoryShow ChangeCategoryShow
        {
            get => editCategory;
            set
            {
                editCategory = value;
                if(editCategory== EditCategoryShow.Both)
                {
                    this.tblType.ColumnStyles[0].SizeType = SizeType.Percent;
                    this.tblType.ColumnStyles[0].Width = this.tblType.Width * 0.5f;
                    this.tblType.ColumnStyles[1].SizeType = SizeType.Percent;
                    this.tblType.ColumnStyles[1].Width = this.tblType.Width * 0.5f;

                    this.tblLine.ColumnStyles[0].SizeType = SizeType.Percent;
                    this.tblLine.ColumnStyles[0].Width = this.tblType.Width * 0.5f;
                    this.tblLine.ColumnStyles[1].SizeType = SizeType.Percent;
                    this.tblLine.ColumnStyles[1].Width = this.tblType.Width * 0.5f;
                }
                else if(editCategory== EditCategoryShow.Expense)
                {
                    this.tblType.ColumnStyles[0].SizeType = SizeType.Percent;
                    this.tblType.ColumnStyles[0].Width = this.tblType.Width * 1f;
                    this.tblType.ColumnStyles[1].SizeType = SizeType.Absolute;
                    this.tblType.ColumnStyles[1].Width = 0;

                    this.tblLine.ColumnStyles[0].SizeType = SizeType.Percent;
                    this.tblLine.ColumnStyles[0].Width = this.tblType.Width * 1f;
                    this.tblLine.ColumnStyles[1].SizeType = SizeType.Absolute;
                    this.tblLine.ColumnStyles[1].Width = 0;
                }
                else if(editCategory== EditCategoryShow.Income)
                {
                    this.tblType.ColumnStyles[0].SizeType = SizeType.Absolute;
                    this.tblType.ColumnStyles[0].Width = 0;
                    this.tblType.ColumnStyles[1].SizeType = SizeType.Percent;
                    this.tblType.ColumnStyles[1].Width = this.tblType.Width * 1f;

                    this.tblLine.ColumnStyles[0].SizeType = SizeType.Absolute;
                    this.tblLine.ColumnStyles[0].Width = 0;
                    this.tblLine.ColumnStyles[1].SizeType = SizeType.Percent;
                    this.tblLine.ColumnStyles[1].Width = this.tblType.Width * 1f;
                }
            }
        }

        public enum EditCategoryShow
        {
            Both,
            Expense,
            Income
        }

        private enum CategoryShowType
        {
            Expense,
            Income,
            Search
        }

        #endregion
        
        #region GetTreeControls

        public void GetTreeControls(bool b)
        {
            if (!this.DesignMode)
            {
                data.Clear();
                data = Communicator.Manager.FetchCategories();

                if (data == null || data.Count == 0) return;
                List<Category> list = data.Where(c => c.Type == b && c.ParentId==0).ToList();
                List<Category> childlist= data.Where(c => c.Type == b && c.ParentId != 0).ToList();
                if (list == null) return;

                if (b)
                {
                    DisposeTrees(incomeTrees);
                    incomeTrees.Clear();
                    pnlIncomeCategory.Controls.Clear();

                    foreach (Category category in list)
                    {
                        TreeControl treeControl = GetTree(category, childlist);
                        pnlIncomeCategory.Controls.Add(treeControl);
                        treeControl.Width = pnlIncomeCategory.Width;

                        incomeTrees.Add(treeControl);
                    }
                }
                else
                {
                    DisposeTrees(expenseTrees);
                    expenseTrees.Clear();
                    pnlExpenseCategory.Controls.Clear();

                    foreach (Category category in list)
                    {
                        TreeControl treeControl = GetTree(category, childlist);
                        pnlExpenseCategory.Controls.Add(treeControl);
                        treeControl.Width = pnlExpenseCategory.Width;

                        expenseTrees.Add(treeControl);
                    }
                }
                ShowCategory(b, Wallet);
                ChangeTreeWidth();
            }
        }
        
        private void ShowCategory(bool b, Wallet w)
        {
            if (!this.DesignMode)
            {
                int branchSpace = 10, xPos = 0, yPos = 10, treeSpace = 10;
                bool walletCheck = false;
                if (b)
                {
                    foreach (TreeControl tree in pnlIncomeCategory.Controls)
                    {
                        walletCheck = ArrangeTree(tree, w, walletCheck);
                        if (walletCheck)
                        {
                            tree.Height += (branchSpace);
                            tree.Location = new Point(xPos, yPos);
                            yPos += (tree.Height + treeSpace);
                        }
                    }
                }
                else
                {
                    foreach (TreeControl tree in pnlExpenseCategory.Controls)
                    {
                        walletCheck = ArrangeTree(tree, w, walletCheck);
                        if (walletCheck)
                        {
                            tree.Height += (branchSpace);
                            tree.Location = new Point(xPos, yPos);
                            yPos += (tree.Height + treeSpace);
                        }
                    }
                }
                ChangeTreeWidth();
            }
        }

        private void ShowCategory(string e)
        {
            if (!this.DesignMode)
            {
                int xPos = 5, yPos = 10, branchSpace = 10;

                List<Category> list = Communicator.Manager.FetchCategories(e);
                if (list == null || list.Count == 0) return;
                list = list.FindAll(i => i.Type == categoryType).ToList();

                DisposeControls(pnlSearch);
                pnlSearch.Controls.Clear();

                foreach (Category c in list)
                {
                    if ((EditMode && WalletChange.WalletID == 0) || c.WalletId.Contains(WalletChange.WalletID))
                    {
                        BranchControl branch = CreateBranch(c);
                        pnlSearch.Controls.Add(branch);
                        branch.Location = new Point(xPos, yPos);
                        yPos += (branch.Height + branchSpace);
                        branch.Width = pnlSearch.Width- 10;
                    }
                }

                if (pnlSearch.VerticalScroll.Visible)
                {
                    foreach (Control c in pnlSearch.Controls) c.Width = pnlSearch.Width - 50;
                }
            }

        }

        //Create Tree
        private TreeControl GetTree(Category category, List<Category> list)
        {
            TreeControl treeControl = new TreeControl();
            treeControl.Name = category.ID.ToString();
            BranchControl branchControl = CreateBranch(category);
            treeControl.Controls.Add(branchControl);

            foreach (Category subCategory in list)
            {
                if (category.ID == subCategory.ParentId)
                {
                    BranchControl child = CreateBranch(subCategory);
                    treeControl.Controls.Add(child);
                }
            }
            return treeControl;
        }

        private bool ArrangeTree(TreeControl tree, Wallet wallet,bool walletCheck)
        {
            walletCheck = false;
            int xPos= 25, yPos = 10, branchSpace= 10, childSpace = 60;
            tree.Height = 0;
            foreach (BranchControl branch in tree.Controls)
            {
                if (wallet != null && branch.Category.WalletId != null && (branch.Category.WalletId.Contains(wallet.WalletID) || wallet.WalletID == 0))
                {
                    if (branch.Category.WalletId.Count != 0 || EditMode)
                    {
                        tree.Height += branch.Height + branchSpace;
                        if (branch.Category.ParentId == 0) branch.Location = new Point(xPos, yPos);
                        else branch.Location = new Point(xPos + childSpace, yPos);
                        yPos += (branch.Height + branchSpace);

                        branch.Show();
                        walletCheck = true;
                    }
                }
                else
                {
                    branch.Hide();
                }
            }
            return walletCheck;
        }

        private BranchControl CreateBranch(Category category)
        {
            BranchControl branch = new BranchControl();

            branch.Click += OnBranchClicked;

            branch.Name = category.ID.ToString();
            branch.Width = 300;
            branch.BranchText = category.CategoryName;
            branch.ImagePath = category.ImagePath;
            branch.Category = category;
            if(category.ParentId==0) branch.Font = new Font("Arial", 12, FontStyle.Bold);
            
            branch.BranchBackColor = GUIStyles.whiteColor;
            branch.OutLineColor = GUIStyles.whiteColor;
            branch.ForeColor = GUIStyles.blackColor;
            return branch;
        }

        private void ChangeTreeWidth()
        {
            if (incomeTrees != null && expenseTrees != null)
            {
                this.SuspendLayout();
                SetTreeWidth(expenseTrees, pnlExpenseCategory);
                SetTreeWidth(incomeTrees, pnlIncomeCategory);
                this.ResumeLayout();
            }
        }

        private void SetTreeWidth(List<TreeControl> trees, Panel panel)
        {
            foreach (TreeControl t in trees)
            {
                if (panel.VerticalScroll.Visible) t.Width = this.Width - 80;
                else
                {
                    if (EditMode) t.Width = this.Width - 40;
                    else
                    {
                        if (Width <= 600) t.Width = this.Width - 100;
                        else t.Width = this.Width - 60;
                    }
                }
            }
        }

        private void DisposeControls(Panel panel)
        {
            foreach (Control control in panel.Controls) control.Dispose();
        }

        private void DisposeTrees(List<TreeControl> trees)
        {
            foreach (TreeControl tree in trees)
            {
                foreach (BranchControl branch in tree.Controls)
                {
                    branch.Dispose();
                    branch.Click -= OnBranchClicked;
                }
                tree.Dispose();
            }
        }

        #endregion

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            pnlIncomeCategory.Hide();
            pnlExpenseCategory.Show();
            pnlExpenseCategory.Dock = DockStyle.Fill;
            pnlExpenseCategory.BringToFront();
            pnlIncomeCategory.Dock = DockStyle.Right;
            pnlSearch.Hide();
            
            pnlExpense.BackColor = GUIStyles.primaryColor;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ChangeTreeWidth();
        }

        private void OnMouseEntered(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.Name != "lblAddCategory")
            {
                control.BackColor = GUIStyles.secondaryColor;
                control.ForeColor = GUIStyles.whiteColor;
            }
            control.Cursor = Cursors.Hand;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.Name != "lblAddCategory")
            {
                control.BackColor = GUIStyles.whiteColor;
                control.ForeColor = GUIStyles.blackColor;
            }
            control.Cursor = Cursors.Arrow;
        }

        private void OnVisibilityChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                this.SuspendLayout();
                if (categoryType) pnlIncomeCategory.Hide();
                else pnlExpenseCategory.Hide();
                categorySearchBar.SearchBarShow = false;
                ModifyCategoryVisibility = false;
                SearchBar?.Invoke(this, EventArgs.Empty);
                pnlSearch.Hide();
                addMode = false;
                modifyCategory.deleteMode = false;
                GetTreeControls(true);
                GetTreeControls(false);
                if (categoryType)
                {
                    pnlIncomeCategory.Show();
                    pnlIncome.BackColor = GUIStyles.primaryColor;
                    pnlExpense.BackColor = Color.Transparent;
                }
                else
                {
                    pnlExpenseCategory.Show();
                    pnlIncome.BackColor = Color.Transparent; 
                    pnlExpense.BackColor = GUIStyles.primaryColor;
                }
                this.ResumeLayout();
            }
            else
            {
                modifyCategory.Hide();
            }
        }

        #endregion

        #region Expense&Income

        private void OnExpenseButtonClicked(object sender, EventArgs e)
        {
            if (!categorySearchBar.SearchBarShow && !modifyCategory.Visible)
            {
                this.SuspendLayout();
                ChangeTreeWidth();
                CategoryVisibleChange(CategoryShowType.Expense);
                this.ResumeLayout();
            }
            categorySearchBar.SearchBarShow = false;
            SearchBar?.Invoke(this, EventArgs.Empty);
        }

        private void OnIncomeBtnClicked(object sender, EventArgs e)
        {
            if (!categorySearchBar.SearchBarShow && !modifyCategory.Visible)
            {
                this.SuspendLayout();
                ChangeTreeWidth();
                CategoryVisibleChange(CategoryShowType.Income);
                this.ResumeLayout();
            }
            categorySearchBar.SearchBarShow = false;
            SearchBar?.Invoke(this, EventArgs.Empty);
        }

        private void CategoryVisibleChange(CategoryShowType showType)
        {
            if(showType== CategoryShowType.Expense)
            {
                pnlSearch.Hide();
                pnlIncomeCategory.Hide();

                pnlExpenseCategory.Dock = DockStyle.Fill;
                pnlExpenseCategory.BringToFront();
                pnlIncomeCategory.Dock = DockStyle.Right;
                
                pnlExpenseCategory.Show();

                pnlExpense.BackColor = GUIStyles.primaryColor;
                pnlIncome.BackColor = Color.Transparent;
                categoryType = false;
            }
            else if (showType == CategoryShowType.Income)
            {
                pnlSearch.Hide();
                pnlExpenseCategory.Hide();

                pnlIncomeCategory.Dock = DockStyle.Fill;
                pnlIncomeCategory.BringToFront();
                pnlExpenseCategory.Dock = DockStyle.Left;

                pnlIncomeCategory.Show();

                pnlExpense.BackColor = Color.Transparent;
                pnlIncome.BackColor = GUIStyles.primaryColor;
                categoryType = true;
            }
            else if(showType == CategoryShowType.Search)
            {
                pnlIncomeCategory.Hide();
                pnlExpenseCategory.Hide();

                pnlIncomeCategory.Dock = DockStyle.Right;
                pnlExpenseCategory.Dock = DockStyle.Left;
                pnlSearch.Dock = DockStyle.Fill;

                pnlSearch.Show();
            }
        }

        #endregion
        
        #region SearchBar

        private void OnSearchBackClicked(object sender, EventArgs e)
        {
            categorySearchBar.Width = 50;
            if (categoryType) CategoryVisibleChange(CategoryShowType.Income);
            else CategoryVisibleChange(CategoryShowType.Expense);
            pnlSearch.Hide();
        }

        private void OnSearchBarClicked(object sender, EventArgs e)
        {
            categorySearchBar.Width = this.Width;
        }
        
        private void OnSeachBarTextChanged(object sender, string e)
        {
            if (e == "")
            {
                if (categoryType) CategoryVisibleChange(CategoryShowType.Income);
                else CategoryVisibleChange(CategoryShowType.Expense);
            }
            else
            {
                CategoryVisibleChange(CategoryShowType.Search);
                ShowCategory(e);
            }
        }

        #endregion

        #region AddCategory

        private void OnAddCategoryBtnClicked(object sender, EventArgs e)
        {
            if (!modifyCategory.Visible)
            {
                if (categoryType) pnlIncomeCategory.Hide();
                else pnlExpenseCategory.Hide();
                
                categorySearchBar.SearchBarShow = false;
                SearchBar?.Invoke(this, EventArgs.Empty);

                modifyCategory.GetData(new Category { Type = categoryType, WalletId= new List<int>() { 1} }, ModifyCategory.CategoryMode.AddMode);
                modifyCategory.Show();
                modifyCategory.BringToFront();
                modifyCategory.Location = new Point(((Width / 2) - (modifyCategory.Width / 2)), ((Height / 2) - (modifyCategory.Height / 2)));
                addMode = true;

                pnlSearch.Hide();
                if (categoryType) pnlIncomeCategory.Show();
                else pnlExpenseCategory.Show();
            }
        }

        #endregion

        #region Category Change

        private void OnCategoryClosed(object sender, EventArgs e)
        {
            this.SuspendLayout();
            CategoryChange(categoryType);
            this.ResumeLayout();
        }
        
        private void OnCategoryChanged(object sender, Category e)
        {
            this.SuspendLayout();
            CategoryChange(e.Type);
            this.ResumeLayout();
        }

        private void CategoryChange(bool type)
        {
            if (type)
            {
                pnlIncomeCategory.Hide();
                GetTreeControls(type);
                CategoryVisibleChange(CategoryShowType.Income);
            }
            else
            {
                pnlExpenseCategory.Hide();
                GetTreeControls(type);
                CategoryVisibleChange(CategoryShowType.Expense);
            }
            ChangeTreeWidth();
            if (addMode) addMode = false;
            modifyCategory.Hide();
            categorySearchBar.SearchBarShow = false;
            SearchBar?.Invoke(this, EventArgs.Empty);
        }

        private void OnModifyCategoryVisibilityChanged(object sender, EventArgs e)
        {
            ModifyCategoryVisibility = modifyCategory.Visible;
        }

        #endregion

        #region Wallet change

        private void OnWalletChanged(object sender, EventArgs e)
        {
            if (categoryType)
            {
                if (searchText.Length == 0)
                {
                    pnlIncomeCategory.Hide();
                    GetTreeControls(true);
                    pnlIncomeCategory.Show();
                }
            }
            else
            {
                if (searchText.Length == 0)
                {
                    pnlExpenseCategory.Hide();
                    GetTreeControls(false);
                    pnlExpenseCategory.Show();
                }   
            }
        }

        #endregion

        #region Category Events

        private void OnBranchClicked(object sender, EventArgs e)
        {
            if (!addMode && !modifyCategory.deleteMode && !modifyCategory.Visible)
            {
                if (sender is Control control)
                {
                    Category category = Communicator.Manager.FetchCategoryName(int.Parse(control.Name));
                    if (EditMode)
                    {
                        modifyCategory.GetData(category, ModifyCategory.CategoryMode.EditMode);
                        modifyCategory.Location = new Point(((Width / 2) - (modifyCategory.Width / 2)), ((Height / 2) - (modifyCategory.Height / 2)));
                        modifyCategory.Show();
                        modifyCategory.BringToFront();
                    }
                    else
                    {
                        CategorySelect?.Invoke(null, category);
                        ChangeTreeWidth();
                        pnlSearch.Hide();
                        categorySearchBar.SearchBarShow = false;
                    }
                }
                
            }
        }
        
        private void OnBackBtnClicked(object sender, EventArgs e)
        {
            modifyCategory.Hide();
            CategoryClose?.Invoke(this, EventArgs.Empty);
        }
        
        private void OnColorChanged(bool e)
        {
            categorySearchBar.ColorChange();
            modifyCategory.ColorChange();

            lblTitle.ForeColor = GUIStyles.whiteColor;
            lblExpense.BackColor = lblIncome.BackColor = GUIStyles.whiteColor;
            lblExpense.ForeColor = lblIncome.ForeColor = GUIStyles.blackColor;

            pnlAdd.BackColor = GUIStyles.whiteColor;

            pnlTop.BackColor = pnlLeft.BackColor = pnlRight.BackColor = pnlBottom.BackColor = GUIStyles.primaryColor;
            lblAddCategory.ForeColor = GUIStyles.primaryColor;

            pnlExpense.BackColor = GUIStyles.primaryColor;
            pnlIncome.BackColor = Color.Transparent;

            //ColorChange
            if (GUIStyles.colorName == "black")
            {
                pbAdd.Image = Image.FromFile(".\\CategoryImages\\BlackPlus.png");
            }
            else if (GUIStyles.colorName == "brown")
            {
                pbAdd.Image = Image.FromFile(".\\CategoryImages\\DarkPlus.png");
            }
            else if (GUIStyles.colorName == "red")
            {
                pbAdd.Image = Image.FromFile(".\\CategoryImages\\RedPlus.png");
            }
            else if (GUIStyles.colorName == "orange")
            {
                pbAdd.Image = Image.FromFile(".\\CategoryImages\\OrangePlus.png");
            }
            else if (GUIStyles.colorName == "pink")
            {
                pbAdd.Image = Image.FromFile(".\\CategoryImages\\PinkPlus.png");
            }
            else
            {
                pbAdd.Image = Image.FromFile(".\\CategoryImages\\BluePlus.png");
            }

            this.BackColor = GUIStyles.backColor;
        }

        public void ColorChange()
        {
            OnColorChanged(true);
        }
        
        #endregion
    }
}
