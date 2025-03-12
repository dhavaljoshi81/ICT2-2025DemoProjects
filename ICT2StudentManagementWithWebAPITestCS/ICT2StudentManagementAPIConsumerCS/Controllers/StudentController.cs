using ICT2StudentManagementAPIConsumerCS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ICT2StudentManagementAPIConsumerCS.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> students = new List<Student>();
        private HttpClient client;
        private string apiURL = @"https://localhost:7262/api/Students";

        public StudentController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(apiURL);
        }

        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage httpResponse = client.GetAsync(apiURL).Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                students = await httpResponse.Content.ReadFromJsonAsync<List<Student>>();
            }
            return View(students.ToList());
        }

        // GET: StudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Student student = new Student();
            HttpResponseMessage httpResponse = await client.GetAsync(apiURL + "/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                student = await httpResponse.Content.ReadFromJsonAsync<Student>();
            }
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student newStudent)
        {
            try
            {
                var newStudentConent = JsonConvert.SerializeObject(newStudent);

                StringContent stringContent =
                    new StringContent(newStudentConent, System.Text.Encoding.UTF8,
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var httpResponse = await client.PostAsync(apiURL, stringContent);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Student student = new Student();
            HttpResponseMessage httpResponse = await client.GetAsync(apiURL + "/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                student = await httpResponse.Content.ReadFromJsonAsync<Student>();
            }
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Student updatedStudent)
        {
            try
            {
                var newStudentConent = JsonConvert.SerializeObject(updatedStudent);
                StringContent stringContent =
                    new StringContent(newStudentConent, System.Text.Encoding.UTF8,
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage httpResponse = await client.PutAsync(apiURL + "/" + id, stringContent);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Student student = new Student();
            HttpResponseMessage httpResponse = await client.GetAsync(apiURL + "/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                student = await httpResponse.Content.ReadFromJsonAsync<Student>();
            }
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(apiURL);
                HttpResponseMessage httpResponse = await client.DeleteAsync(apiURL + "/" + id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
