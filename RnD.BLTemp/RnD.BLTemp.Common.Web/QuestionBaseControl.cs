using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using RnD.BLTemp.BusinessEntity;
using RnD.BLTemp.BusinessObject;

namespace RnD.BLTemp.Common.Web
{
    public abstract class QuestionBaseControl : System.Web.UI.UserControl
    {
        public delegate void ValueChangedEventHandler(int changedQuestion, int effectedQuestionID);
        public event ValueChangedEventHandler ValueChanged;

        //public BEQuestionValidations Validations = new BEQuestionValidations();

        public QuestionBaseControl()
        {
            this.NeedOtherOption = false;
            this.ShowNote = false;
            this.ShowSerial = true;
            this.QuestionType = 1; //1= Label  2= Text Box 3 =CheckBox 4 =Drop Down 5 Date Time;
            this.QustionTitle = string.Empty;
            this.SerialFormat = "00";
            this.QuestionSerial = 1;
            this.NoteTitle = "Note";
            this.NoteBody = "This is sample not body";

            this.AnsWidth = 200;
            this.OtherAnsWidth = 200;
            //    this.AnsHeight = 20;
            this.OtherAnsHeight = 20;
            this.IsViewMode = false;
        }

        //public bool ChangedValue
        //{
        //    set
        //    {
        //        if (ValueChanged != null)
        //            ValueChanged(this.Question.QuestionId, this.Question.ChildQuestionID);
        //    }
        //}

        public bool IsViewMode { get; set; }
        public abstract void RefreshData(int parent);

        //public abstract BEAnswers Value { get; set; }

        public bool NeedOtherOption { get; set; }
        public int QuestionType { get; set; }
        public string QustionTitle { get; set; }
        public bool ShowSerial { get; set; }
        public string SerialFormat { get; set; }
        public int QuestionSerial { get; set; }
        public string NoteTitle { get; set; }
        public string NoteBody { get; set; }
        public bool ShowNote { get; set; }
        public int AnsWidth { get; set; }
        public int OtherAnsWidth { get; set; }
        public int AnsHeight { get; set; }
        public int OtherAnsHeight { get; set; }


        private bool bolIsInitialized = true;

        public bool IsInitialized
        {
            set { this.bolIsInitialized = value; }
            get { return this.bolIsInitialized; }
        }

        //public BEQuestion Question { set; get; }

        public Int32 Index { set; get; }

        //public abstract BEAnswers BuildAnswers(BEAnswers answers);

        public Int32 ICONID { set; get; }
        public Int32 ComplainId { set; get; }

        //public BEAnswers Answers { set; get; }

        public RnD.BLTemp.Common.Web.Common.PageModeEnum PageMode { set; get; }
        public bool ShowIndex { set; get; }
        public bool ShowAnswerPrefix { set; get; }

        public abstract bool IsValid(ref string errMsg);

        protected abstract void LoadData();
        protected abstract void ShowHide();
        protected abstract void BindData();
    }
}
