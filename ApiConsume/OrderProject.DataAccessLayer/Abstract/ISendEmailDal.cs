using HotelProject.DataAccessLayer.Abstract;
using OrderProject.DtoLayer.Mail;
using OrderProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.DataAccessLayer.Abstract
{
    public interface ISendEmailDal:IGenericDal<SendEmail>
    {
        public void AddSendEmail(AddSendEmailDto sendEmail);
    }
}
