console.log("Welcome");
var BASEURL = "https://localhost:5001/api/"
let fetchApprovedDrivers = async () => {
  let unLandlords = await fetch(`${BASEURL}Driver/GetApprovedDrivers`);
  let jsonUnLandlords = await unLandlords.json();
  console.log(jsonUnLandlords); 
  return jsonUnLandlords;
} 
let displayApprovedDrivers = async () => {
    console.log("1");
    let count = 0;
    const response = await fetchApprovedDrivers();
    let tableData = document.querySelector("#approvedDrivers");
    response.data.forEach(element => {
      localStorage.setItem("driverId", element.id)
        count++;
    tableData.innerHTML += `<tr>
            <td>${count}</td>
            <img width="100px" height="100px" src ="https://localhost:5001/api/Images/${element.image}" alt"">
            <td>${element.firstName}</td>
            <td>${element.lastName}</td>
            <td>${element.phoneNumber}</td>
            <td>${element.email}</td>
            <img width="100px" height="100px" src ="https://localhost:5001/api/Images/${element.license}" alt"">
            <td><button style="background-color: red"  class="my-btn btn btn-primary mr-2" id="${element.id}" >Deactivate</button></td>
            
            
    </tr>`
  });
  deactivateDriver();
}
function deactivateDriver () {
  buttons = document.querySelectorAll(".my-btn");
  buttons.forEach(btn => {
    console.log("sehhhhhhhhhhhh");
    btn.addEventListener('click', (e) => {
      fetch(`https://localhost:5001/api/Driver/Deactivatedriver/${e.target.id}`, {
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
displayApprovedDrivers();

// let logOut = () =>{
//   localStorage.clear();
//   window.location.href = "/index.html";
// }

// function setLandlordNae() {
//   let getName = document.querySelector(".name");
//    getName.textContent = localStorage.getItem("LandlordName");
// } 
// setLandlordNae();


// let displayDate = () => {
//   var d = new Date;
//   let day = d.getDate();
//   let month = d.getMonth();
//   let year = d.getFullYear();
//   let getdate = document.querySelector("#date");
//   getdate.textContent = `Today   :    ${day}/${month + 1}/${year}`
// }

// displayDate();