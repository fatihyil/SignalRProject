using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _IbookingDal;

        public BookingManager(IBookingDal IbookingDal)
        {
            _IbookingDal = IbookingDal;
        }

        public void TAdd(Booking entity)
        {
            _IbookingDal.Add(entity);
        }

        public void TDelete(Booking entity)
        {
            _IbookingDal.Delete(entity);    
        }

        public Booking TGetById(int Id)
        {
            return _IbookingDal.GetById(Id);
        }

        public List<Booking> TGetListAll()
        {
            return _IbookingDal.GetListAll();
        }

        public void TUpdate(Booking entity)
        {
            _IbookingDal.Update(entity);
        }
    }
}
