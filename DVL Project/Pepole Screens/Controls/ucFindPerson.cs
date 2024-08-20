using DrivingBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project
{
    public partial class ucFindPerson : UserControl
    {
        // Define a custom event handler delegate with parameter.
        public event Action<int> OnFindPerson;
        // Create method to raise event with a parameter.
        protected virtual void FindPerson(int PersonID)
        {
            Action <int> handler = OnFindPerson;

            if (handler != null)
            {
                handler(PersonID); // Raise event with the parameter.
            }

        }

        // Define a custom event handler delegate with parameter.
        public event Action<int> OnResetInfo;
        // Create method to raise event with a parameter.
        protected virtual void ResetInfo(int PersonID)
        {
            Action<int> handler = OnResetInfo;

            if (handler != null)
            {
                handler(PersonID); // Raise event with the parameter.
            }

        }

        public ucFindPerson()
        {
            InitializeComponent();
        }

        void _SearchBy()
        {

            if (cbFindBy.Text == "PersonID")
            {
                if (int.TryParse(tbSearch.Text, out int Personid))
                {

                    if (ucPersonalInfo1.LoadPersonInfo(Personid))
                    {
                        if (OnFindPerson != null && gbFilter.Enabled)
                        {
                            FindPerson(Personid); // event Action.
                        } 
                    } 

                    return;
                }
                else
                {
                    tbSearch.Clear();
                    return;
                }
            }

            if (cbFindBy.Text == "NationalNo")
            {
                // return PersonID from ucPersonalInfo1 and send to event Action
                string NationalNo = tbSearch.Text;

                if (ucPersonalInfo1.LoadPersonInfo(NationalNo))
                {
                    if (OnFindPerson != null && gbFilter.Enabled)
                    {
                        FindPerson(ucPersonalInfo1.PersonID); // event Action.
                    }
                }

                return;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _SearchBy();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbFindBy.SelectedIndex = 0; // select ('PersonID') Mode.
            tbSearch.Clear();
            ucPersonalInfo1.Reset();
            
            if (OnResetInfo != null && gbFilter.Enabled)
            {
                ResetInfo(-1); // -1 = No Person.
            }
        }

        private void ucFindPerson_Load(object sender, EventArgs e)
        {
            cbFindBy.SelectedIndex = 0; // select ('PersonID').
        }

        public void Enable()
        {
            gbFilter.Enabled = true;
        }

        public void Disable()
        {
            gbFilter.Enabled = false;
        }

        public void LoadPersonInfo(string NationalNo)
        {
            cbFindBy.SelectedIndex = 1; // select (NaitonalNo) mode.

            tbSearch.Text = NationalNo;

            _SearchBy();

            Disable(); // disable Search.
        }

    }
}
