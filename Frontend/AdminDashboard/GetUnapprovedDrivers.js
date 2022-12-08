console.log("Welcome");
var BASEURL = "https://localhost:5001/api/"
let fetchUnapprovedDrivers = async () => {
  let unLandlords = await fetch(`${BASEURL}Driver/GetUnapprovedDrivers`);
  let jsonUnLandlords = await unLandlords.json();
  console.log(jsonUnLandlords); 
  return jsonUnLandlords;
} 
let displayUnapprovedDrivers = async () => {
    let count = 0;
    const response = await fetchUnapprovedDrivers();
    let tableData = document.querySelector("#unapprovedDrivers");
    response.data.forEach(element => {
        count++;
    tableData.innerHTML += `<tr>
            <td>${count}</td>
            <img width="100px" height="100px" src = "https://localhost:5001/api/Images/${element.image}" alt"">
            <td>${element.firstName}</td>
            <td>${element.lastName}</td>
            <td>${element.phoneNumber}</td>
            <td>${element.email}</td>
            <td><button style="background-color: yellow" class="my-btn btn btn-primary mr-2" id="${element.id}" >Approve</button></td>
            <td><button style="background-color: Black" class="my-btn2 btn btn-primary mr-2" id="${element.id}" >Vehicles</button></td>
    </tr>`
  });
  approveDriver();
  redirect();
}
function approveDriver () {
  buttons = document.querySelectorAll(".my-btn");
  buttons.forEach(btn => {
    console.log("sehhhhhhhhhhhh");
    btn.addEventListener('click', (e) => {
      fetch(`https://localhost:5001/api/Driver/ApproveDriver/${e.target.id}`, {
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
              location.reload();
            }
        })
        .catch((resp) => {
           
        })   
    })
  })
}
displayUnapprovedDrivers();

const redirect = () => {
  buttons = document.querySelectorAll(".my-btn2");
  buttons.forEach(btn => {
    btn.addEventListener('click', (e) => {
      window.location.href = `/AdminDashboard/GetDriversVehicles.html?id=${e.target.id}`
    })
  })
}


let getUnapprovedDriversCount = async () => {
  let unLandlords = await fetch('https://localhost:5001/api/Driver/GetUnapprovedDriversCount');
  let jsonUnLandlords = await unLandlords.json();
  console.log(jsonUnLandlords); 
  return jsonUnLandlords;
} 

let displayCount = async () => {
  var id = localStorage.getItem("adminId")
  console.log(id)
  const count =await getUnapprovedDriversCount()
  console.log(count);
  let display = document.getElementById("ud")
  display.innerHTML += count;
}
displayCount();



let logOut = () =>{
  localStorage.clear();
  window.location.href = "/index.html";
}

