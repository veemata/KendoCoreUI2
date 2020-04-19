$(document).ready(function () {
    //start of the document ready function
    //delcaring global variable to hold primary key value.
    var rowId;
    $('.delete-prompt').click(function () {
        rowId = $(this).attr('id');
        $('#myModal').modal('show');
    });

    $('.delete-confirm').click(function () {
        if (rowId != '') {
            $.ajax({
                url: 'PopupAddEdit/Delete',
                data: { 'Id': rowId },
                type: 'post',
                success: function (data) {
                    if (data) {
                        //now re-using the boostrap modal popup to show success message.
                        //dynamically we will change background colour
                        if ($('.modal-header').hasClass('alert-danger')) {
                            $('.modal-header').removeClass('alert-danger').addClass('alert-success');
                            //hide ok button as it is not necessary
                            $('.delete-confirm').css('display', 'none');
                        }
                        $('.success-message').html('Record deleted successfully');
                    }
                }, error: function (err) {
                    if (!$('.modal-header').hasClass('alert-danger')) {
                        $('.modal-header').removeClass('alert-success').addClass('alert-danger');
                        $('.delete-confirm').css('display', 'none');
                    }
                    $('.success-message').html(err.statusText);
                }
            });
        }
    });

    //function to reset bootstrap modal popups
    $("#myModal").on("hidden.bs.modal", function () {
        $(".modal-header").removeClass(' ').addClass('alert-danger');
        $('.delete-confirm').css('display', 'inline-block');
        $('.success-message').html('').html('Are you sure you wish to delete this record ?');
    });

    //end of the docuement ready function
});