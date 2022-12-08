let nameValue = document.querySelector("#Name");
let emailValue = document.querySelector("#Email");
let numberValue = document.querySelector("#PhoneNumber");
let load = document.querySelector("#submit");

function Submit(){
    console.log("seen");
    Data = {
        name : nameValue.value,
        email : emailValue.value,
        phoneNumber : numberValue.value,
    };
    load.innerHTML = `<div class="loading add-loading"></div>`
    nameValue.textContent = "";
    emailValue.textContent = "";
    numberValue.textContent = "";
    fetch('https://localhost:5001/api/Passenger/RegisterPassenger`', 
    {
    method : "Post",
    headers : {
        "Content-Type": "application/json"
    },
    body : JSON.stringify(Data)
    })
    .then(res=>res.json())
    .then(data=>{
        console.log(data)
        if(data.success == true)
        {
            alert(data.message);
            
        }
        else if(data.success == false)
        {   
            alert(data.message);
        }    
    })
}



