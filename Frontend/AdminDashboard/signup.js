const myform = document.querySelector('#myform')

myform.addEventListener('submit',(e)=>{
    e.preventDefault();
    let sendform = new FormData(myform);
    console.log(sendform)
    fetch('https://localhost:5001/api/Admin/RegisterAdmin',
    {
        method:"POST",
        body: sendform
    })
    .then(res=>res.json())
    .then(data=>{
        console.log(data)
        
        if(data.success == true)
        {
            // localStorage.setItem("adminId", data.data.id);
            // console.log("id=" ,data.data.id);
            alert(data.message);
            location.href="/index.html"
           
        }
        else if(data.success == false)
        {   
            alert(data.message);
        }
    })
})
