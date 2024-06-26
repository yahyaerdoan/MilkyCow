﻿using MilkyCow.BusinessLayer.Abstract.IAbstractService;
using MilkyCow.DataAccessLayer.Abstract.IAbstractDal;
using MilkyCow.EntityLayer.Concrete;

namespace MilkyCow.BusinessLayer.Concrete.ConcreteManager
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

		public MessageManager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public void Add(Message entity)
        {
            entity.SendingDate = DateTime.Now;
            entity.IsRead = false;
            _messageDal.Add(entity);
        }

        public void Delete(int id)
        {
            _messageDal.Delete(id);
        }

        public List<Message> GetAll()
        {
            var values = _messageDal.GetAll();
            return values;
        }

        public Message GetById(int id)
        {
            var values = _messageDal.GetById(id);
            return values;
        }

        public void Update(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
