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
    public partial class ParentView : UserControl
    {
        public ParentView()
        {
            InitializeComponent();
        }
        
        public event EventHandler ParentCategoryClose;
        public event EventHandler<Category> ParentCategorySelect;

        private bool type = false;
        private CategoryMode mode = CategoryMode.AddMode;
        private Category parentCategory = new Category();
        private List<BranchControl> expenseBranch = new List<BranchControl>();
        private List<BranchControl> incomeBranch = new List<BranchControl>();
        private List<Category> data = new List<Category>();
        
        public bool Type
        {
            get => type;
            set
            {
                type = value;
                ShowCategory();
                if (type == false) tcParent.SelectedTab = expenseTabPage;
                else tcParent.SelectedTab = incomeTabPage;
            }
        }

        public CategoryMode Mode
        {
            get => mode;
            set
            {
                mode = value;
            }
        }

        public Category ParentCategory
        {
            get => parentCategory;
            set
            {
                if (value == null) return;
                parentCategory = value;
            }
        }

        public enum CategoryMode
        {
            AddMode,
            EditMode
        };
        
        #region GetBranch and Locate branch

        public void GetBranches(bool b)
        {
            data.Clear();
            data = Communicator.Manager.FetchParentCategories();
            if (data == null || data.Count == 0) return;

            List<Category> list = data.Where(c => c.Type == b).ToList();
            if (list == null || list.Count == 0) return;

            if (b)
            {
                //Dispose
                DisposeBranch(incomeBranch);
                incomeBranch.Clear();
                pnlIncome.Controls.Clear();

                foreach (Category category in list)
                {
                    BranchControl branchControl = CreateBranch(category);
                    pnlIncome.Controls.Add(branchControl);
                    incomeBranch.Add(branchControl);
                }

            }
            else
            {
                //Dispose
                DisposeBranch(expenseBranch);
                expenseBranch.Clear();
                pnlExpense.Controls.Clear();

                foreach (Category category in list)
                {
                    BranchControl branchControl = CreateBranch(category);
                    pnlExpense.Controls.Add(branchControl);
                    expenseBranch.Add(branchControl);
                }
            }

        }
        
        private void ShowCategory()
        {
            int xPos = 5, yPos = 20, branchSpace = 10, id=0;

            Category category = new Category();
            if (ParentCategory.ParentId != 0) category = Communicator.Manager.FetchCategoryName(ParentCategory.ParentId);

            if (Type)
            {
                pnlIncome.VerticalScroll.Value = 0;
                foreach (BranchControl b in pnlIncome.Controls)
                {
                    id = int.Parse(b.Name);
                    if ((Mode == CategoryMode.EditMode) && ((ParentCategory != null && id == ParentCategory.ID) || (category.ID != 0 && category.ID == id))) b.Visible = false;
                    else
                    {
                        b.Visible = true;
                        b.Location = new Point(xPos, yPos);
                        yPos += (b.Height + branchSpace);
                    }
                }
                
                SetBranchWidth(pnlIncome);
            }
            else
            {
                pnlExpense.VerticalScroll.Value = 0;
                foreach (BranchControl b in pnlExpense.Controls)
                {
                    if ((Mode == CategoryMode.EditMode) && ((ParentCategory != null && id == ParentCategory.ID) || (category.ID != 0 && category.ID == id))) b.Visible = false;
                    else
                    {
                        b.Visible = true;
                        b.Location = new Point(xPos, yPos);
                        yPos += (b.Height + branchSpace);
                    }
                }
                
                SetBranchWidth(pnlExpense);
            }
        }

        private BranchControl CreateBranch(Category category)
        {
            BranchControl branchControl = new BranchControl();
            branchControl.ImagePath = category.ImagePath;
            branchControl.Name = category.ID.ToString();
            branchControl.BranchText = category.CategoryName;

            branchControl.BranchBackColor = GUIStyles.whiteColor;
            branchControl.OutLineColor = GUIStyles.backColor;
            branchControl.ForeColor = GUIStyles.blackColor;

            branchControl.Click += OnBranchClicked;

            return branchControl;
        }

        private void SetBranchWidth(Panel panel)
        {
            bool scrollCheck = false;
            if (panel.VerticalScroll.Visible) scrollCheck = true;
            foreach(Control control in panel.Controls)
            {
                if (scrollCheck) control.Width = tcParent.Width - 45;
                else control.Width = tcParent.Width - 25;
            }
        }

        private void DisposeBranch(List<BranchControl> branches)
        {
            if (branches == null) return;
            foreach(BranchControl branch in branches)
            {
                branch.Click -= OnBranchClicked;
                branch.Dispose();
            }
        }

        #endregion

        #region Branch Events

        private void OnBranchClicked(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                ParentCategorySelect?.Invoke(null, Communicator.Manager.FetchCategoryName(int.Parse(control.Name)));
                parentSearchBar.SearchBarShow = false;
            }
        }

        private void OnBackBtnClicked(object sender, EventArgs e)
        {
            ParentCategoryClose?.Invoke(this, EventArgs.Empty);
            parentSearchBar.SearchBarShow = false;
        }

        #endregion

        #region Search Branches

        private void OnSearchBarClicked(object sender, EventArgs e)
        {
            parentSearchBar.Width = this.Width;
        }

        private void OnSearchBackClicked(object sender, EventArgs e)
        {
            parentSearchBar.Width = 50;
            ShowCategory();
        }
        
        private void OnSearchBarTextChanged(object sender, string e)
        {
            if (e == "") ShowCategory();
            else
            {
                List<Category> list = Communicator.Manager.FetchCategories(e);
                ShowCategory(list);
            }
        }

        private void ShowCategory(List<Category> list)
        {
            list = list.FindAll(i => i.Type == Type).ToList();
            List<int> listOfId = list.Select(i => i.ID).ToList();

            if (listOfId == null) return;

            if (Type)
            {
                pnlIncome.VerticalScroll.Value = 0;
                GetSearchedBranches(pnlIncome, listOfId);
            }
            else
            {
                pnlExpense.VerticalScroll.Value = 0;
                GetSearchedBranches(pnlExpense, listOfId);
            }

        }

        private void GetSearchedBranches(Panel panel, List<int> listOfId)
        {
            int xPos = 5, yPos = 20, branchSpace = 10, id = 0;

            foreach (BranchControl b in panel.Controls)
            {
                id = int.Parse(b.Name);
                if (!listOfId.Contains(id) || parentCategory.ID == id) b.Visible = false;
                else
                {
                    b.Visible = true;
                    b.Location = new Point(xPos, yPos);
                    yPos += (b.Height + branchSpace);
                }
            }
            SetBranchWidth(panel);
        }

        #endregion

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GetBranches(true);
            GetBranches(false);
            ShowCategory();
            expenseTabPage.BackColor = incomeTabPage.BackColor = GUIStyles.backColor;
        }

        private void OnVisibilityChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                parentSearchBar.SearchBarShow = false;
                GetBranches(true);
                GetBranches(false);
                ShowCategory();
            }
        }

        public void ColorChange()
        {
            parentSearchBar.ColorChange();
            pnlTop.BackColor = pnlRight.BackColor = pnlLeft.BackColor = pnlBottom.BackColor = GUIStyles.primaryColor;
            lblTitle.ForeColor = GUIStyles.whiteColor;
            this.BackColor = GUIStyles.backColor;

            expenseTabPage.BackColor = incomeTabPage.BackColor = GUIStyles.backColor;
        }

        #endregion
    }
}
