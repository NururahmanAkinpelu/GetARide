console.log("Welcome");
var BASEURL = "https://localhost:5001/api/"
let fetchActivePassengers = async () => {
  let unLandlords = await fetch(`${BASEURL}Passenger/GetActivePassengers`);
  let jsonUnLandlords = await unLandlords.json();
  console.log(jsonUnLandlords); 
  return jsonUnLandlords;
} 
let displayActivePassengers = async () => {
    console.log("1");
    let count = 0;
    const response = await fetchActivePassengers();
    let tableData = document.querySelector("#activepassengers");
    response.passengerDTOs.forEach(element => {
        count++;
    tableData.innerHTML += `<tr>
            <td>${count}</td>
            <td>${element.name}</td>
            <td>${element.phoneNumber}</td>
            <td>${element.email}</td>
            <td><button style="background-color: red"   class="ver-btn btn btn-primary mr-2" id="${element.id}" >Deactivate</button></td>
    </tr>`
    deactivateCustomer();
  });
}


function deactivateCustomer () {
  buttons = document.querySelectorAll(".ver-btn");
  buttons.forEach(btn => {
    console.log("sehhhhhhhhhhhh");
    btn.addEventListener('click', (e) => {
      fetch(`https://localhost:5001/api/Passenger/DeactivatePassenger/${e.target.id}`, {
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
displayActivePassengers();



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