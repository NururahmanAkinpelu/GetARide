console.log("Welcome");
var BASEURL = "https://localhost:5001/api/"
let fetchDeactivedPassengers = async () => {
  let unLandlords = await fetch(`${BASEURL}Passenger/GetDeactivatedPassengers`);
  let jsonUnLandlords = await unLandlords.json();
  console.log(jsonUnLandlords); 
  return jsonUnLandlords;
} 
let displayDeactivedPassengers = async () => {
    console.log("1");
    let count = 0;
    const response = await fetchDeactivedPassengers();
    let tableData = document.querySelector("#passengers");
    response.passengerDTOs.forEach(element => {
        count++;
    tableData.innerHTML += `<tr>
            <td>${count}</td>
            <td>${element.name}</td>
            <td>${element.phoneNumber}</td>
            <td>${element.email}</td>
            <td><button style="background-color: green" class="my-btn btn btn-primary mr-2" id="${element.id}" >Activate</button></td>
    </tr>`
  });
  
}


let activateCustomer = () =>{
  buttons = document.querySelectorAll(".my-btn");
  buttons.forEach(btn => {
    btn.addEventListener('click', (e) => {
      fetch(`https://localhost:5001/api/Passenger/ActivatePassenger/${e.target.id}`, {
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
              
            }
        })
        .catch((resp) => {
           
        })   
    })
  })
}




let logOut = () =>{
  localStorage.clear();
  window.location.href = "/index.html";
}




// let displayDate = () => {
//   var d = new Date;
//   let day = d.getDate();
//   let month = d.getMonth();
//   let year = d.getFullYear();
//   let getdate = document.querySelector("#date");
//   getdate.textContent = `Today   :    ${day}/${month + 1}/${year}`
// }

// displayDate();