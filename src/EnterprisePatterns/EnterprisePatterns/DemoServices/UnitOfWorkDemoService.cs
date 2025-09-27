using EnterprisePatterns.Entities;
using EnterprisePatterns.UnitsOfWork;

namespace EnterprisePatterns.DemoServices
{
    public class UnitOfWorkDemoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkDemoService(IUnitOfWork unitOfWork) // can also inject specific repo here if you need it (IOrderLineRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task RunAsync()
        {
            var orderRepo = _unitOfWork.Repository<Order>();
            var orderLineRepo = _unitOfWork.Repository<OrderLine>();


            var order = new Order("Generic UoW with multiple repos");
            await orderRepo.AddAsync(order);

            var line = new OrderLine("Product", 1) { Order = order };
            await orderLineRepo.AddAsync(line);

            await _unitOfWork.CommitAsync();
        }
    }


    //public class UnitOfWorkDemoService
    //{
    //    private readonly CreateOrderWithOrderLinesUnitOfWork _unitOfWork;

    //    public UnitOfWorkDemoService(CreateOrderWithOrderLinesUnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork;
    //    }
    //    public async Task RunAsync()
    //    {
    //        // create an order
    //        Order orderToAadd = new Order("My birthday order");
    //        _unitOfWork.OrderRepository.Add(orderToAadd);

    //        //create orderline

    //        OrderLine orderLineToAdd = new("A product I bought on bday", 1) { Order = orderToAadd };

    //        _unitOfWork.OrderLineRepository.Add(orderLineToAdd);

    //        //persist changes

    //        await _unitOfWork.CommitAsync();
    //    }
    //}
}
