console.log("Pass");
var id = localStorage.getItem("passengerId")
console.log("passengerid =", id)
const form = document.querySelector("#form");

form.addEventListener("submit",(e)=>
{
    e.preventDefault();
    let sendform = new FormData(form);
    console.log(sendform)
    fetch('https://localhost:5001/api/Trip/CreateTrip',
    {
        method:"POST",
        body: sendform
        // header : {
        //     "content-type" : "application/problem+json"
        // }
    })
    .then(res=>res.json())
    .then(data=>{
        console.log(data)
  
        if(data.success == true)
        {
            localStorage.setItem("tripId", data.tripDto.id)  
            Booking() 
            // location.href="vehclesignup.html"
        
        }
        else if(data.success == false)
        {   
            alert(data.message);
        }
    })

});
var tripId = localStorage.getItem("tripId")
function Booking()
{
    let myform =document.querySelector("#form");
    form.addEventListener("submit",(e)=>{
    e.preventDefault();
})
   
    fetch(`https://localhost:5001/api/Orders/MakeOrder/${tripId}/${id}`, 
    {
        method : "POST",
        headers : {
            "Content-Type": "application/json"
        }
    })
    .then((respose) => {
        
        return respose.json();
    })
    .then(function (value) {
        console.log(value);
            if(value.success == true)
            {
                console.log("seen")
                window.alert("Order Sent,.. wait for driver")                             
            }
            else
            {
                alert(value.message)
            }
            
    })
    .catch((resp) => {
        console.log("jh")
        console.log(resp.error);
    })
}



   
 




