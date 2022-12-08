console.log("Welcome");
var driverId = localStorage.getItem("driverId");
console.log(driverId);
var BASEURL = "https://localhost:5001/api/"
let fetchBookings = async () => {
  let unBookings = await fetch(`https://localhost:5001/api/Orders/GetAllCreatedOrderByLocation/odoeran`);
  let jsonBookings = await unBookings.json();
  console.log(jsonBookings); 
  return jsonBookings;
} 
let displayBookings = async () => {
    console.log("1");
    let count = 0;
    const response = await fetchBookings();
    let tableData = document.querySelector("#bookings");
    response.bookingDtos.forEach(element => {
        count++;
    tableData.innerHTML += `<tr>
            <td>${count}</td>
            <td>${element.startLocation}</td>
            <td>${element.endLocation}</td>
            <td>${element.type}</td>
            <td><button style="background-color: black" class="my-btn btn btn-primary mr-2" id="${element.id}" >Accept</button></td>
    </tr>`
  });
  AcceptBooking()
}
function AcceptBooking()
{
  buttons = document.querySelectorAll(".my-btn");
  buttons.forEach(btn => {
    console.log("sehhhhhhhhhhhh");
    btn.addEventListener('click', (e) => {
      console.log(e.target.id);
      console.log(driverId)
      fetch(`https://localhost:5001/api/Orders/AcceptOrder/${e.target.id}/${driverId}`, {
        method : "PUT",
       })
       .then((respose) => {
        return respose.json();
        })
        .then(function (value) {
            console.log(value);
            if(value.success == true)
            {
              alert(value.message)
              location.href = "Google Map/index.html"
            }
            else if (value.success == false) 
            {
              alert(value.message)
            }
        })
        .catch((resp) => {
           
        })   
    })
  })
}

displayBookings();

let logOut = () =>{
  localStorage.clear();
  window.location.href = "/index.html";
}
