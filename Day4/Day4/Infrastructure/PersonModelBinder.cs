using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day4.Models;

namespace Day4.Infrastructure
{
    public class PersonModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Person model = (Person) bindingContext.Model ?? new Person();
            model.FirstName = GetValue(bindingContext, "FirstName");
            model.LastName = GetValue(bindingContext, "LastName");
            model.Birthday = GetBirthday(controllerContext,bindingContext);
            model.Role = GetRole(controllerContext, bindingContext);
            model.HomeAddress = GetAddress(controllerContext, bindingContext);
            model.AddressSummary = GetAddressSummary(model.HomeAddress);
            return model;
        }

        public string GetValue(ModelBindingContext context, string name)
        {
            name = (context.ModelName == "" ? "" : context.ModelName + ".") + name;
            ValueProviderResult result = context.ValueProvider.GetValue(name);
            if (result == null || result.AttemptedValue == "")
            {
                return "<Not Specified>";
            }
            return result.AttemptedValue;
        }

        private Role GetRole(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string roleString = GetValue(bindingContext, "Role");
            Role role;
            if (!Enum.TryParse(roleString, out role))
                roleString = "<not specified>";
            switch (roleString.ToLower())
            {
                case "<not specified>":
                    return Role.Guest;
                case "admin":
                    return !controllerContext.HttpContext.Request.IsLocal ? Role.User : Role.Admin;
                default:
                    return (Role)Enum.Parse(typeof(Role), roleString);
            }
        }

        private DateTime GetBirthday(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            DateTime dt;
            DateTime.TryParseExact(GetValue(bindingContext, "Birthday"), "yyyy-dd-MM",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
            return dt;
        }

        private Address GetAddress(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Address address = new Address();
            address.City = GetValue(bindingContext,"HomeAddress.City") == "PO BOX" ? "<Not Specified>" : GetValue(bindingContext, "HomeAddress.City");
            address.Country = GetValue(bindingContext, "HomeAddress.Country") == "PO BOX" ? "<Not Specified>" : GetValue(bindingContext, "HomeAddress.Country");
            address.Line1 = GetValue(bindingContext, "HomeAddress.Line1");
            address.Line2 = GetValue(bindingContext, "HomeAddress.Line2");
            address.PostalCode = GetValue(bindingContext, "HomeAddress.PostalCode").Length < 6 ? "<Not Specified>" : GetValue(bindingContext, "HomeAddress.PostalCode");
            return address;
        }

        private string GetAddressSummary(Address address)
        {
            if (address.PostalCode == "<Not Specified>" || address.City == "<Not Specified>" ||
                address.Line1 == "<Not Specified>")
                return "No Personal Address";
            return $"{address.PostalCode} {address.City},{address.Line1}";
        }
    }
}