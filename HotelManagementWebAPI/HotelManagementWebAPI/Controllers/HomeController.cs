using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelManagementWebAPI.Models;

namespace HotelManagementWebAPI.Controllers
{
    public class HomeController : ApiController
    {
        private static List<HotelModel> _HotelDetails = new List<HotelModel>
        {
            new HotelModel {Id=1,Name="Hyaat Hotel", NumberOfAvailableRooms=5, Address="Pune", PinCode=140000},
            new HotelModel {Id=2,Name="Oyo Hotel", NumberOfAvailableRooms=4, Address="Pune", PinCode=140000},
            new HotelModel {Id=3,Name="Oyo Hotel2", NumberOfAvailableRooms=6, Address="Pune", PinCode=140000}
        };

        [HttpGet]
        public HttpResponseMessage GETHotelDetails()
        {
            if (_HotelDetails != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, _HotelDetails);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Hotels Not Found");
            }
        }

        [HttpGet]
        public HttpResponseMessage GETHotelDetailsByID(int id)
        {
            HotelModel HotelDetailsByID = new HotelModel();
           HotelDetailsByID = _HotelDetails.Find(Hotel => Hotel.Id.Equals(id));
            if (HotelDetailsByID != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, HotelDetailsByID);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Hotel Not Found");
            }
        }
        [HttpPost]
        public HttpResponseMessage POSTNewHotel(HotelModel hotelModel)
        {
                if (hotelModel != null)
                {
                    _HotelDetails.Add(hotelModel);
                    return Request.CreateResponse(HttpStatusCode.OK, _HotelDetails);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Hotel Not Updated - InternalServerError");
                }
        }
        [HttpDelete]
        public HttpResponseMessage DeleteHotelDetailsByID(int id)
        {
            HotelModel HotelDetailsByID = new HotelModel();
            HotelDetailsByID = _HotelDetails.Find(Hotel => Hotel.Id.Equals(id));
            if (HotelDetailsByID != null)
            {
                _HotelDetails.RemoveAt(HotelDetailsByID.Id - 1);
                return Request.CreateResponse(HttpStatusCode.OK, _HotelDetails);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Invalid ID");
            }
        }
        [HttpPut]
        public ApiResponse UpdateHotelDetailsByID(int id, HotelModel hotelModel)
        {
            ApiResponse AResponse = new ApiResponse();
            try
            {
                HotelModel HotelDetailsByID = new HotelModel();
                HotelDetailsByID = _HotelDetails.Find(Hotel => Hotel.Id.Equals(id));
                if (HotelDetailsByID != null)
                {
                    HotelDetailsByID.Id = hotelModel.Id;
                    HotelDetailsByID.Name = hotelModel.Name;
                    HotelDetailsByID.NumberOfAvailableRooms = hotelModel.NumberOfAvailableRooms;
                    HotelDetailsByID.Address = hotelModel.Address;
                    HotelDetailsByID.PinCode = hotelModel.PinCode;
                    AResponse.ApiStatus = "Success";
                    AResponse.StatusCode = StatusCodeNumber.Success;
                    AResponse.Message = "Successfully Updated";
                }
            }
            catch (Exception ex)
            {
                AResponse.ApiStatus = "Failure";
                AResponse.StatusCode = StatusCodeNumber.InternalServerError;
                AResponse.Message = ex.Message;
            }
            return AResponse;
        }
        //[HttpPut]
        //public ApiResponse BookHotelDetailsByID(int id, [FromBody]int rooms) //For Booking
        //{
        //    ApiResponse AResponse = new ApiResponse();
        //    try
        //    {
        //        HotelModel HotelDetailsByID = new HotelModel();
        //        HotelDetailsByID = _HotelDetails.Find(Hotel => Hotel.Id.Equals(id));
        //        if (HotelDetailsByID != null)
        //        {
        //            HotelDetailsByID.NumberOfAvailableRooms = HotelDetailsByID.NumberOfAvailableRooms - rooms ;
        //            AResponse.ApiStatus = "Success";
        //            AResponse.StatusCode = StatusCodeNumber.Success;
        //            AResponse.Message = "Successfully Booked";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AResponse.ApiStatus = "Failure";
        //        AResponse.StatusCode = StatusCodeNumber.InternalServerError;
        //        AResponse.Message = ex.Message;
        //    }
        //    return AResponse;
        //}
    }
}
