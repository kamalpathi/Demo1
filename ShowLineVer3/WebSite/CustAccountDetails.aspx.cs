using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShowLineVer3.Model;
using ShowLineVer3.ViewModel;

namespace ShowLineVer3.WebSite
{
    public partial class CustAccountDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetEventDetails();
                    GetCustDetails();
                    GetCustTransaction();
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

        protected void GetCustDetails()
        {
            try
            {
                if (Session["UserName"] != null)
                {

                    CustomerLoginViewModel customerLoginViewModel = new CustomerLoginViewModel();
                    List<CustomerModel> custModel = new List<CustomerModel>();
                    string uid = Session["UserName"].ToString();
                    custModel = customerLoginViewModel.GetCustomerDetails(uid);
                    customerLoginViewModel = null;

                    firstname.Value = custModel[0].firstname;
                    lastname.Value = custModel[0].lastname;
                    address1.Value = custModel[0].address1;
                    address2.Value = custModel[0].address2;
                    city.Value = custModel[0].city;
                    state.Value = custModel[0].state;
                    zip.Value = custModel[0].zip;
                    mobileno.Value = custModel[0].mobileno;
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

        private void GetEventDetails()
        {
            try
            {
                EventListingViewModel _eventListingViewModel = new EventListingViewModel();
                List<EventListingModel> _eventListingModel = new List<EventListingModel>();

                _eventListingModel = _eventListingViewModel.GetEventListing();
              
                rcontent.DataSource = _eventListingModel.Take(4);
                rcontent.DataBind();

                //rQuickBook.DataSource = _eventListingModel;
                //rQuickBook.DataBind();

                //rFeatured.DataSource = _eventListingModel.Take(4);
                //rFeatured.DataBind();
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

        protected void accountdetails_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (ValidateAccountDetails() == true)
                {
                    if (Session["UserName"] != null)
                    {
                        CustomerLoginViewModel customerLoginViewModel = new CustomerLoginViewModel();
                        CustomerModel custModel = new CustomerModel();

                        custModel.firstname = firstname.Value.Trim();
                        custModel.lastname = lastname.Value.Trim();
                        custModel.address1 = address1.Value.Trim();
                        custModel.address2 = address2.Value.Trim();
                        custModel.city = city.Value.Trim();
                        custModel.state = state.Value.Trim();
                        custModel.zip = zip.Value.Trim();
                        custModel.mobileno = mobileno.Value.Trim();
                        string uid = Session["UserName"].ToString();

                        customerLoginViewModel.UpdateCustomerDetails(custModel, uid);

                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Account Details updated','Account Details');</script>", false);

                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

        protected void bchangepassword_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    if (ValidateChangePassword() == true)
                    {
                        CustomerLoginViewModel customerLoginViewModel = new CustomerLoginViewModel();
                        string uid = Session["UserName"].ToString();
                        string retval = customerLoginViewModel.CustomerChangePassword(uid, newpassword.Value.Trim(), currentpassword.Value.Trim());
                        customerLoginViewModel = null;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Your password has been changed.','Account Details');</script>", false);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Login", "ShowProcessing('T')", true);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

        private bool ValidateChangePassword()
        {
            try
            {
                bool retval = true;

                if (currentpassword.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter current password.','Change Password: Validation');</script>", false);
                    retval = false;
                }

                if (newpassword.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter new password.','Change Password: Validation');</script>", false);
                    retval = false;
                }

                if (confirmpassword.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter confirm password.','Change Password: Validation');</script>", false);
                    retval = false;
                }

                if (newpassword.Value.Trim() != confirmpassword.Value.Trim())
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Password Mismatch.','Change Password: Validation');</script>", false);
                    retval = false;
                }

                return retval;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return false;
            }
        }

        private bool ValidateAccountDetails()
        {
            try
            {
                bool retval = true;

                if (firstname.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter fist name.','Change Password: Validation');</script>", false);
                    retval = false;
                }

                if (lastname.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter last name.','Change Password: Validation');</script>", false);
                    retval = false;
                }

                if (mobileno.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Add Event Validation", "<script type='text/javascript'>CheckValidation('Please enter mobile number.','Change Password: Validation');</script>", false);
                    retval = false;
                }


                return retval;
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
                return false;
            }
        }

        private void GetCustTransaction()
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    CustomerLoginViewModel customerLoginViewModel = new CustomerLoginViewModel();
                    List<CustTransactionModel> custTransModel = new List<CustTransactionModel>();

                    string uid = Session["UserName"].ToString();
                    custTransModel = customerLoginViewModel.GetCustTransactionDetails(uid);
                    grdTransaction.DataSource = custTransModel;
                    grdTransaction.DataBind();
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }

        protected void grdTransaction_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Print Click
                    e.Row.Cells[7].Attributes.Add("onclick", "return onRespose('" + ((Label)e.Row.Cells[0].Controls[1]).Text + "','" +  ((Label)e.Row.Cells[4].Controls[1]).Text  + "')");
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteError(ex.Message);
            }
        }
    }
}