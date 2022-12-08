console.log("Welcome");
var BASEURL = "https://localhost:5001/api/"
let fetchDeactiveAdmins = async () => {
  let unLandlords = await fetch(`${BASEURL}Admin/GetAllDeactivatedAdmins`);
  let jsonUnLandlords = await unLandlords.json();
  console.log(jsonUnLandlords); 
  return jsonUnLandlords;
} 
let displayDeactivedAdmins = async () => {
    console.log("1");
    let count = 0;
    const response = await fetchDeactiveAdmins();
    let tableData = document.querySelector("#alladmins");
    response.adminDTOs.forEach(element => {
        count++;
    tableData.innerHTML += `<tr>
            <td>${count}</td>
            <td>${element.fullName}</td>
            <td>${element.phoneNumber}</td>
            <td>${element.email}</td>
            <td><button style="background-color: green" class="my-btn btn btn-primary mr-2" id="${element.id}" >Activate</button></td>
    </tr>`
  });
  activateAdmin();
}
function activateAdmin () {
  buttons = document.querySelectorAll(".my-btn");
  buttons.forEach(btn => {
    console.log("sehhhhhhhhhhhh");
    btn.addEventListener('click', (e) => {
      fetch(`https://localhost:5001/api/Admin/ActivateAdmin/${e.target.id}`, {
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
displayDeactivedAdmins();

let logOut = () =>{
  localStorage.clear();
  window.location.href = "/index.html";
}

function setLandlordNae() {
  let getName = document.querySelector(".name");
   getName.textContent = localStorage.getItem("LandlordName");
} 
setLandlordNae();


let displayDate = () => {
  var d = new Date;
  let day = d.getDate();
  let month = d.getMonth();
  let year = d.getFullYear();
  let getdate = document.querySelector("#date");
  getdate.textContent = `Today   :    ${day}/${month + 1}/${year}`
}

displayDate();