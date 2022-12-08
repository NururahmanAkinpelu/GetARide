var id = window.location.href.split('=')[1];
console.log(id)

let fetchVehicles = async () => {
  let unLandlords = await fetch(`https://localhost:5001/api/Vehicle/GetAllDriversVehicle/${id}`);
  let jsonUnLandlords = await unLandlords.json();
  console.log(jsonUnLandlords); 
  return jsonUnLandlords;
} 
let displayVehicles = async () => {  
    let count = 0;
    const response = await fetchVehicles();
    let tableData = document.querySelector("#vehicles");
    response.data.forEach(element => {
        count++;
    tableData.innerHTML += `<tr>
            <td>${count}</td>
            <img width="100px" height="100px" src = "https://localhost:5001/api/Images/${element.documents}" alt"">
            <td>${element.name}</td>
            <td>${element.model}</td>
            <td>${element.colour}</td>
            <td>${element.plateNumber}</td>
            <td>${element.type}</td>
    </tr>`
    })
  };   

displayVehicles()