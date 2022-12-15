console.log("Welcome");
var driverId = localStorage.getItem("userId");
console.log(driverId);
var BASEURL = "https://localhost:5001/api/"
let fetchVehicles = async () => {
  let unvehicles = await fetch(`${BASEURL}Vehicle/GetAllDriversVehicle/${driverId}`);
  let jsonUnVehicles = await unvehicles.json();
  console.log(jsonUnVehicles); 
  return jsonUnVehicles;
} 
let displayVehicles = async () => {
    console.log("1");
    let count = 0;
    const response = await fetchVehicles();
    let tableData = document.querySelector("#vehicles");
    response.data.forEach(element => {
        count++;
    tableData.innerHTML += `<tr>
            <td>${count}</td>
            <img width="100px" height="100px" src = "https://localhost:5001/api/Documents/${element.documents}" alt"">
            <td>${element.name}</td>
            <td>${element.model}</td>
            <td>${element.colour}</td>
            <td>${element.plateNumber}</td>
            <td><button style="background-color: red" class="my-btn btn btn-primary mr-2" id="${element.id}" >Remove</button></td>
    </tr>`
     console.log(element.id)
  });
  RemoveVehicle();
}

function RemoveVehicle () 
{
  buttons = document.querySelectorAll(".my-btn");
  buttons.forEach(btn => {
    console.log("sehhhhhhhhhhhh");
    btn.addEventListener('click', (e) => {
      console.log(e.target.id);
      fetch(`https://localhost:5001/api/Vehicle/Deletevehicle/${e.target.id}`, {
        method : "DELETE",
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
displayVehicles();



