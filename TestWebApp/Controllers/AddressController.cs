//using System;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using TestWebApp.Models;

//namespace TestWebApp.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AddressController : ControllerBase
//    {
//        public Address _address { get; }

//        public AddressController(Address repo)
//        {
//            _address = repo;
//        }

//        [HttpPost("{customerId}")]
//        public async Task<IActionResult> CreateAddress(int customerId, Address address)
//        {
//            try
//            {
//                address.CustomerId = customerId;
//                address.CreatedAt = DateTime.Now;

//                _address.Create(address);

//                if (await _address.SaveChangesAsync())
//                {
//                    return Ok(address);
//                }
//            }
//            catch (System.Exception ex)
//            {
//                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
//            }

//            return BadRequest("Não foi possível salvar as informações");
//        }

//        [HttpPut]
//        public async Task<IActionResult> UpdateAddress(Address address)
//        {
//            try
//            {
//                var addressAux = await _address.GetAddressByIdAsync(address.Id);

//                if (addressAux == null)
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    addressAux.Street = address.Street;
//                    addressAux.Number = address.Number;
//                    addressAux.ZipCode = address.ZipCode;
//                    addressAux.Complement = address.Complement;
//                    addressAux.City = address.City;
//                    addressAux.State = address.State;
//                    addressAux.MainAddress = address.MainAddress;
//                    addressAux.UpdatedAt = DateTime.Now;

//                    _address.Update(addressAux);

//                    if (await _address.SaveChangesAsync())
//                    {
//                        return Ok(addressAux);
//                    }
//                }
//            }
//            catch (System.Exception ex)
//            {
//                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
//            }

//            return BadRequest("Não foi possível salvar as informações");
//        }

//        [HttpDelete("{addressId}")]
//        public async Task<IActionResult> DeleteAddress(int addressId)
//        {
//            try
//            {
//                var addressAux = await _address.GetAddressByIdAsync(addressId);


//                if (addressAux == null)
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    _address.Delete(addressAux);

//                    if (await _address.SaveChangesAsync())
//                    {
//                        return Ok();
//                    }
//                }
//            }
//            catch (System.Exception ex)
//            {
//                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
//            }

//            return BadRequest("Não foi possível excluir as informações");
//        }

//        [HttpGet("{addressId}")]
//        public async Task<IActionResult> GetAddressByIdAsync(int addressId)
//        {
//            try
//            {
//                var address = await _address.GetAddressByIdAsync(addressId);

//                return Ok(address);
//            }
//            catch (System.Exception ex)
//            {
//                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
//            }
//        }

//        [HttpGet("list/{customerId?}")]
//        public async Task<IActionResult> ListAllAddressesAsync(int? customerId)
//        {
//            try
//            {
//                var addresses = await _address.GetAllAddressesAsync(customerId);

//                return Ok(addresses);
//            }
//            catch (System.Exception ex)
//            {
//                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
//            }
//        }
//    }
//}
