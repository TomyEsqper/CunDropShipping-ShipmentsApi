using CunDropShipping_Shipments.adapter.restful.v1.controller.Entity;
using CunDropShipping_Shipments.adapter.restful.v1.controller.Mapper;
using CunDropShipping_Shipments.application.Service;
using Microsoft.AspNetCore.Mvc;

namespace CunDropShipping_Shipments.adapter.Controller
{
    /// <summary>
    /// Controlador REST para gestionar la creación y consulta de envíos.
    /// Expone endpoints de la API en la ruta "api/v1/shipments" y traduce entre
    /// las entidades del adaptador (API) y las entidades del dominio.
    /// </summary>
    [ApiController]
    [Route("api/v1/shipments")]
    public class ShipmentController : ControllerBase
    {
        // 1. El recepcionista necesita hablar con el coordinador (IShipmentService)
        private readonly IShipmentsService _shipmentService;
        private readonly IAdapterMapper _adapterMapper;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="ShipmentController" />.
        /// </summary>
        /// <param name="shipmentService">Servicio de aplicación que contiene la lógica de negocio relacionada con envíos.</param>
        /// <param name="adapterMapper">Mapper encargado de convertir entre entidades del adaptador (API) y entidades del dominio.</param>
        // 2. El constructor recibe al coordinador por inyección de dependencias
        public ShipmentController(IShipmentsService shipmentService, IAdapterMapper adapterMapper)
        {
            _shipmentService = shipmentService;
            _adapterMapper = adapterMapper;
        }

        /// <summary>
        /// Obtiene todos los envíos registrados.
        /// </summary>
        /// <returns>Un <see cref="ActionResult"/> que contiene una lista de <see cref="AdapterShipmentsEntity"/> y un código HTTP 200 en caso de éxito.</returns>
        // 3. Define el primer método: Obtener todos los envíos
        [HttpGet]
        public ActionResult<List<AdapterShipmentEntity>> GetAllShipments()
        {
            // Llama al servicio para obtener la lista de envíos (internos)
            var domainShipments = _shipmentService.GetAllShipments();
            
            // Usa el mapper para traducir la lista interna a una lista pública
            return Ok(_adapterMapper.ToAdapterShipmentList(domainShipments));
        }

        /// <summary>
        /// Obtiene un envío por su número de seguimiento (Tracking Number).
        /// </summary>
        /// <param name="trackingNumber">Número de seguimiento único del envío a recuperar.</param>
        /// <returns>
        /// Un <see cref="ActionResult"/> que contiene la entidad <see cref="AdapterShipmentsEntity"/> y un código HTTP 200 si se encuentra.
        /// Devuelve 404 NotFound si no existe el envío con el número de seguimiento proporcionado.
        /// </returns>
        [HttpGet("{trackingNumber}")]
        public ActionResult<AdapterShipmentEntity> GetShipmentByTrackingNumber(string trackingNumber)
        {
            var shipment = _shipmentService.GetShipmentByTrakingNumber(trackingNumber);
            if (shipment == null)
            {
                // Si el servicio no encontró el envío, devolvemos un 404 Not Found.
                return NotFound($"No se encontró el envío con el número de seguimiento: {trackingNumber}");
            }

            // Si lo encontró, lo traducimos y lo devolvemos con un 200 OK.
            return Ok(_adapterMapper.ToAdapterShipment(shipment));
        }

        /// <summary>
        /// Crea un nuevo envío. El sistema generará automáticamente el número de seguimiento y la fecha.
        /// </summary>
        /// <returns>
        /// Un <see cref="ActionResult"/> que contiene la entidad creada <see cref="AdapterShipmentsEntity"/> y un código HTTP 201 Created.
        /// Incluye la ubicación del recurso creado en la cabecera Location.
        /// </returns>
        [HttpPost]
        public ActionResult<AdapterShipmentEntity> CreateShipment([FromBody] AdapterShipmentEntity shipment)
        {
            // 1. Crea una entidad de dominio vacía para que el servicio la procese.
            var domainShipment = _adapterMapper.ToDomainShipment(shipment);

            // 2. Llama al servicio para que cree el envío (generando tracking number, fecha, etc.).
            var createdShipment = _shipmentService.CreateShipment(domainShipment);

            // 3. Traduce el envío guardado (que ya tiene Id y TrackingNumber) de vuelta al formato del cliente.
            var adapterResult = _adapterMapper.ToAdapterShipment(createdShipment);

            // 4. Devuelve una respuesta "201 Created", que es el estándar para un POST exitoso.
            //    Incluye la URL para encontrar el nuevo recurso y el objeto creado.
            return CreatedAtAction(nameof(GetShipmentByTrackingNumber), new { trackingNumber = adapterResult.TrackingNumber }, adapterResult);
        }
    }
}