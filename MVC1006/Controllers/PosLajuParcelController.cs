using Microsoft.AspNetCore.Mvc;
using MVC1006.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Numerics;

namespace MVC1006.Controllers
{
    public class PosLajuParcelController : Controller
    {
        private readonly IConfiguration configuration; 
        public PosLajuParcelController(IConfiguration config) { 
            this.configuration = config; 
        }

        public IActionResult Index()
        {
            IList<PosLajuParcel> dbList = new List<PosLajuParcel>(); 
            SqlConnection conn = new SqlConnection(configuration.GetConnectionString("ParcelConnStr"));

            string sql = @"SELECT ParcelId, ParcelDateTime, SenderName, SenderPhone, 
            ReceiverName, ReceiverAddress, ReceiverPhone, IndexWeight, Amount 
            FROM PosLajuParcels";
            
            SqlCommand cmd = new SqlCommand(sql, conn);

            // try
            // {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
                
            while (reader.Read())
            {
                dbList.Add(new PosLajuParcel()
                {
                    // ParcelId = reader.GetString(0),
                    ViewId = reader.GetString(0),
                    // ParcelDateTime = reader.GetDateTime(1),
                    ViewDateTime = reader.GetDateTime(1),
                    SenderName = reader.GetString(2),
                    SenderPhone = reader.GetString(3),
                    ReceiverName = reader.GetString(4),
                    ReceiverAddress = reader.GetString(5),
                    ReceiverPhone = reader.GetString(6),
                    IndexWeight = reader.GetInt32(7),
                    Amount = reader.GetDouble(8),
                });
            }
                // }
                // catch
                // {
                // RedirectToAction("Error");

                // }
                // finally
                // {
            conn.Close();
                // }

                return View(dbList);
        }

        public IActionResult Details(string id)
        {
            IList<PosLajuParcel> dbList = GetDbList();

            var result = dbList.First(x => x.ViewId == id);

            return View(result);    
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            IList<PosLajuParcel> dbList = GetDbList();

            var result = dbList.First(x => x.ViewId == id);

            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(string id, PosLajuParcel parcel)
        {
            SqlConnection conn = new SqlConnection(configuration.GetConnectionString("ParcelConnStr"));
            SqlCommand cmd = new SqlCommand("spUpdateParcel", conn); 
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@receivername", parcel.ReceiverName); 
            cmd.Parameters.AddWithValue("@receiveraddress", parcel.ReceiverAddress); 
            cmd.Parameters.AddWithValue("@receiverphone", parcel.ReceiverPhone); 
            cmd.Parameters.AddWithValue("@receiveremail", parcel.ReceiverEmail);

            // try
            // {
            conn.Open();
            cmd.ExecuteNonQuery();
            // }
            // catch
            // {
            // RedirectToAction("Error");
            // }
            // finally
            // {
            conn.Close();
            // }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            IList<PosLajuParcel> dbList = GetDbList();

            var result = dbList.First(x => x.ViewId == id);

            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(string id)
        {
            SqlConnection conn = new SqlConnection(configuration.GetConnectionString("ParcelConnStr"));
            SqlCommand cmd = new SqlCommand("spDeleteParcel", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        IList<PosLajuParcel> GetDbList()
        {
            IList<PosLajuParcel> dbList = new List<PosLajuParcel>();
            SqlConnection conn = new SqlConnection(configuration.GetConnectionString("ParcelConnStr"));

            string sql = @"SELECT * FROM PosLajuParcels";

            SqlCommand cmd = new SqlCommand(sql, conn);

            // try
            // {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dbList.Add(new PosLajuParcel()
                {
                    ViewId = reader.GetString(0),
                    ViewDateTime = reader.GetDateTime(1),
                    SenderName = reader.GetString(2),
                    SenderAddress = reader.GetString(3),
                    SenderPhone = reader.GetString(4),
                    SenderEmail = reader.GetString(5),
                    ReceiverName = reader.GetString(6),
                    ReceiverAddress = reader.GetString(7),
                    ReceiverPhone = reader.GetString(8),
                    ReceiverEmail = reader.GetString(9),
                    IndexWeight = reader.GetInt32(10),
                    IndexZone = reader.GetInt32(11),
                    Amount = reader.GetDouble(12)
                });
            }
            // }
            // catch
            // {
            // RedirectToAction("Error");

            // }
            // finally
            // {
            conn.Close();
            // }

            return dbList;
        }

        public IActionResult SearchIndex(string searchString = "")
        {
            IList<PosLajuParcel> dbList = GetDbList();

            var result = dbList.Where(x => x.ViewId.ToLower().Contains(searchString.ToLower()) ||
            x.SenderName.ToLower().Contains(searchString.ToLower())).OrderBy(x => x.SenderName).ThenByDescending(x => x.ViewDateTime);

            return View("Index", result);
        }

        [HttpGet]
        public IActionResult ParcelDelivery()
        {
            PosLajuParcel p = new PosLajuParcel();

            p.IndexWeight = p.IndexZone = -1;

            return View(p);
        }

        [HttpPost]
        public IActionResult ParcelDelivery(PosLajuParcel p)
        {
            // if (ModelState.IsValid)
            // {
                SqlConnection conn = new SqlConnection(configuration.GetConnectionString("ParcelConnStr"));
                SqlCommand cmd = new SqlCommand("spInsertParcel", conn); 
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@parcelid", p.ParcelId); 
                cmd.Parameters.AddWithValue("@parceldatetime", p.ParcelDateTime);
                cmd.Parameters.AddWithValue("@sendername", p.SenderName);
                cmd.Parameters.AddWithValue("@senderaddress", p.SenderAddress);
                cmd.Parameters.AddWithValue("@senderphone", p.SenderPhone);
                
                if (p.SenderEmail != null)
                    cmd.Parameters.AddWithValue("@senderemail", p.SenderEmail);
                else
                    cmd.Parameters.AddWithValue("@senderemail", "");
                
                cmd.Parameters.AddWithValue("@receivername", p.ReceiverName);
                cmd.Parameters.AddWithValue("@receiveraddress", p.ReceiverAddress);
                cmd.Parameters.AddWithValue("@receiverphone", p.ReceiverPhone);
                
                if (p.ReceiverEmail != null)
                    cmd.Parameters.AddWithValue("@receiveremail", p.ReceiverEmail);
                else
                    cmd.Parameters.AddWithValue("@receiveremail", "");
                
                cmd.Parameters.AddWithValue("@indexweight", p.IndexWeight);
                cmd.Parameters.AddWithValue("@indexzone", p.IndexZone);
                cmd.Parameters.AddWithValue("@amount", p.Amount);

                // try
                // {
                conn.Open();
                cmd.ExecuteNonQuery();
                // }
                // catch
                // {
                // return View(p);
                // }
                // finally
                // {
                conn.Close();
                // }

                return View("ParcelDeliveryInvoice", p);
            // }
            // else
               //  return View(p);
        }
    }
}
