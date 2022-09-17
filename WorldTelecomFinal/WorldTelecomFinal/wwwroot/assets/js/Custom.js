


$(document).ready(function () {

    //$('.searchinput').keyup(function () {
    //    let search = $(this).val();
    //    console.log(search)

    //    let url = $(this).data('url');
    //    console.log(url);

    //    url = url + '?search=' + search
    //    console.log(url)

    //    fetch(url).then(res => {
    //        //console.log(response.json())
    //        return res.json();
    //    }).then(data =>
    //    {
    //        let listitems = "";

    //        console.log(data)

    //        for (var i = 0; i < data.products.length; i++) {
    //            let liitem = `<li  class="list-group-item" style="display:flex; list-style-type:none; padding:5px; color:black; border:1px solid black; width:88%; height:auto; border-radius:5px; background-color:white;">
    //                <img src="assets/img/productjpg/${data.products[i].mainImage}" style="width:60px" />
    //                <p style="margin-top:auto; margin-bottom:auto; display:block;">${data.products[i].name}</p>
    //        </li>`

    //            listitems += liitem
    //        }

    //        console.log(listitems)

    //        $('.search-box .list-group').html(listitems)
    //    })
    //})


    //-----------------------Partial View ucun Elave olaraq Search ----------------------

    $('.searchinput').keyup(function () {

        let inputvalue = $(this).val().trim();

        console.log(inputvalue)

        let url = $(this).data('url')
        console.log(url)

        url = url + '?search=' + inputvalue;
        console.log(url);

        if (inputvalue) {
            fetch(url)
                .then(res => res.text())
                .then(data => {
                    $('.search-box .list-group').html(data);
                })
        } else {
            $('.search-box .list-group').html('');
        }

        
    })

})