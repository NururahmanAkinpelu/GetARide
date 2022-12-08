let emailValue = document.querySelector("#email1");
let passwordValue = document.querySelector("#psw");
let load = document.querySelector("#myformvalue");


load.addEventListener('submit',(e) => {
    e.preventDefault();
    console.log("seen");
   Data = {
    email : emailValue.value,
    password : passwordValue.value,
   };
   console.log(Data.email);
   fetch('https://localhost:5001/api/User/Login', {
    method : "POST",
    headers : {
        "Content-Type": "application/json"
    },
    body : JSON.stringify(Data)
   })
   .then((respose) => {
    return respose.json();
    })
    .then(function (value) {
        localStorage.setItem("setToken", value.token);
        console.log(localStorage.getItem("setToken"));
        console.log(value);
        if(value.data.success == true)
        {
            console.log("bhdhfh")
            console.log(value.data.roles);
            localStorage.setItem("userName", value.data.name);
            value.data.roles.forEach(element => {
                if (element.name == "Passenger") 
                {
                    var passengerId = localStorage.setItem("passengerId", value.data.id)
                    console.log("id =", passengerId);
                    console.log("over");
                    location.href = "/PassengerLandingPage.html"
                }
                else if (element.name == "Admin")
                {
                    var adminId =  localStorage.setItem("adminId", value.data.id)
                    location.href = "AdminDashboard/index.html"
                    console.log(adminId);
                }
                else if (element.name == "Driver" ) 
                {
                    var driverId = localStorage.setItem("driverId", value.data.id)
                    location.href = "Driver/GetBookings.html"
                    console.log(driverId);
                }
            });
        }
        else
        {
            console.log("ldlnffhhrhhr")
            window.alert(value.message);
        }
            
    })
      
});
