$(document).ready(function () {
    $(document).on('click', '.delete-btn-admin', function (e) {
        e.preventDefault();
        

        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {

                let url = $(this).attr('href');
                fetch(url)
                    .then(res => res.text())
                    .then(data => { $('.tbl-content').html(data) });

                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            }
        })



        fetch(url)
            .then(res => res.text())
            .then(data => { $('.tbl-content').html(data) });
    })

    $(document).on('click', '.restore-btn-admin', function (e) {
        e.preventDefault();


        Swal.fire({
            title: 'Are you sure?',
            text: "You want RESTORE this?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {

                let url = $(this).attr('href');
                console.log(url);
                fetch(url)
                    .then(res => res.text())
                    .then(data => { $('.tbl-content').html(data) });

                Swal.fire(
                    'Restored!',
                    'Your file has been Restored.',
                    'success'
                )
            }
        })

        fetch(url)
            .then(res => res.text())
            .then(data => { $('.tbl-content').html(data) });
    })



    if ($('.isMainInput').is(":checked")) {
        $('.imagecontainer').removeClass('d-none');
        $('.parentcontainer').addClass('d-none');
    } else {
        $('.imagecontainer').addClass('d-none');
        $('.parentcontainer').removeClass('d-none');
    }

    $(document).on('change', '.isMainInput', function () {
        $(document).on('change', '.isMainInput', function () {
            console.log($(this).is(":checked"))
            if ($(this).is(":checked")) {
                $('.imagecontainer').removeClass('d-none');
                $('.parentcontainer').addClass('d-none');
            } else {
                $('.imagecontainer').addClass('d-none');
                $('.parentcontainer').removeClass('d-none');
            }
        })
    } )
})
