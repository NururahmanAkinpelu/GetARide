
// let nameValue = document.querySelector("#Name");
// let modelValue = document.querySelector("#Model");
// let colourValue = document.querySelector("#Colour");
// let plateValue = document.querySelector("#PlateNumber");

// let sub = document.querySelector("#submit2");
// sub.addEventListener("click", (e) =>{
//     e.preventDefault();
// })
// let docValue = document.querySelector("#Document");
// var driverId = localStorage.getItem("driverId");
// console.log(driverId);
// function RegisterVehicle()
// {

//     Data = {
//         name : nameValue.value,
//         mode : modelValue.value,
//         colour : colourValue.value,
//         plateNumber : plateValue.value,
//         document : docValue.value,
//         driverId : driverId
//     };
//     fetch(`https://localhost:5001/api/Vehicle/RegisterVehicle`, {
//      method : "POST",
//      headers : {
//          "Content-Type": "application/json"
//      },
//      body : Data
//     })
//     .then(res=>res.json())
//      .then(data=>{
//          console.log(data)
//          if(data.success == true)
//          {
//              alert(data.message);
//              location.href = "/index.html";
         
//          }
//          else if(data.success == false)
//          {   
//              alert(data.message);
//          }
//      })
// }

var driverId = localStorage.getItem("driverId");
console.log(driverId);
const myform = document.querySelector('#myform2')
myform.addEventListener('submit',(e)=>{
    e.preventDefault();
    let sendform = new FormData(myform);
    console.log(sendform)
    fetch(`https://localhost:5001/api/Vehicle/RegisterVehicle/${driverId}`,{
        method:"POST",
        body: sendform
    })
    .then(res=>res.json())
    .then(data=>{
        console.log(data)     
        if(data.success == true)
        {
            alert(data.message);
            location.href="/index.html";
           
        }
        else if(data.success == false)
        {   
            alert(data.message);
        }
    })
})
