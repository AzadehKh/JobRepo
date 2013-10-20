using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace JobRepo
{
   [Serializable]
    public class RecentSearchGroup //: ProfileGroupBase
    {
        public RecentSearchGroup()
        {
        }

  //      [SettingsAllowAnonymous(true)]
       [CustomProviderData("Keywords;nvarchar")]
        public virtual string Keywords { get; set; }
    }


   [Serializable]
   public class SecurityQuestionsGroup 
   {
       public SecurityQuestionsGroup()
       {
       }


       [CustomProviderData("Question1;nvarchar")]
       public virtual string Question1 { get; set; }
       [CustomProviderData("Answer1;nvarchar")]
       public virtual string Answer1 { get; set; }
       [CustomProviderData("Question2;nvarchar")]
       public virtual string Question2 { get; set; }
       [CustomProviderData("Answer2;nvarchar")]
       public virtual string Answer2 { get; set; }
   }

    public class ProfileCommon : ProfileBase
    {
        //[SettingsAllowAnonymous(true)]
        //[CustomProviderData("Keywords;nvarchar")]
        //public virtual string Keywords
        //{

        //    get
        //    {

        //        return ((string)(this.GetPropertyValue("Keywords")));

        //    }

        //    set
        //    {

        //        this.SetPropertyValue("Keywords", value);

        //    }
        //}

         [SettingsAllowAnonymous(true)]
        public RecentSearchGroup RecentSearch
        {
            get
            {
                RecentSearchGroup rg = new RecentSearchGroup();
                if (this.GetPropertyValue("RecentSearch") != null)
                    rg = (RecentSearchGroup)(this.GetPropertyValue("RecentSearch"));
                return rg;

            }

            set
            {

                this.SetPropertyValue("RecentSearch", value);

            }
        }

         
         [SettingsAllowAnonymous(false)]
         public SecurityQuestionsGroup SecurityQuestions 
         {
             get
             {
                    return (SecurityQuestionsGroup)(this.GetPropertyValue("SecurityQuestions"));
             }

             set
             {

                 this.SetPropertyValue("SecurityQuestions", value);

             }
         }

        public static ProfileCommon GetProfile()
        {
            return (ProfileCommon)HttpContext.Current.Profile;

        }

        public static ProfileCommon GetProfile(string userName)
        {
            return (ProfileCommon)Create(userName);
        }


    }
  
}