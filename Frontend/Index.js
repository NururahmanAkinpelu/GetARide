const myform = document.querySelector('#myform')

function openForm() {
    document.getElementById("popupForm").style.display = "block";
  }
  function closeForm() {
    document.getElementById("popupForm").style.display = "none";
  }

myform.addEventListener('submit',(e)=>{
    e.preventDefault();
    let sendform = new FormData(myform);
    console.log(sendform)
    fetch('https://localhost:5001/api/Passenger/RegisterPassenger',
    {
        method:"POST",
        body: sendform
    })
    .then(res=>res.json())
    .then(data=>{
        console.log(data)
        if(data.success == true)
        {
            alert(data.message);
            openForm();
            
        }
        else if(data.success == false)
        {   
            alert(data.message);
        }
    })
    
})
