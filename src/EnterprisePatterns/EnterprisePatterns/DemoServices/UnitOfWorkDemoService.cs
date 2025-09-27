using EnterprisePatterns.Entities;
using EnterprisePatterns.UnitsOfWork;

namespace EnterprisePatterns.DemoServices
{
    public class UnitOfWorkDemoService
    {
        private readonly CreateOrderWithOrderLinesUnitOfWork _unitOfWork;

        public UnitOfWorkDemoService(CreateOrderWithOrderLinesUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task RunAsync()
        {
            // create an order
            Order orderToAadd = new Order("My birthday order");
            _unitOfWork.OrderRepository.Add(orderToAadd);

            //create orderline

            OrderLine orderLineToAdd = new("A product I bought on bday", 1) { Order = orderToAadd };

            _unitOfWork.OrderLineRepository.Add(orderLineToAdd);

            //persist changes

            await _unitOfWork.CommitAsync();
        }
    }
}
