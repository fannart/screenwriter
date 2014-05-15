$(function () {
	$( '#advSearchButton' ).on('click', function() {
		$('#advancedSearch').slideToggle('slow');
	});
	// Handles all actions to request an existing subtitle.
	$('.requestSubtitle').on('click', function (e) {
		e.preventDefault();
		$this = $(this);
		var href = $this.attr('href');
		var id = $this.attr('data-id');
		$.ajax({
			type: 'GET',
			contentType: 'application/json; charset=utf-8',
			url: href,
			dataType: 'json',
			success: function (value) {
				// TODO: Keep an eye on this functionality if the markup changes.
				// TODO: if value.requestCreated == false, activate error.
				$this.parent().prev().text(value.requestCount);
			},
			error: function () {
				// Error handling for when a user is not registered.
				$('#registerToRequestError').modal();
			}
		});
	});
	// Replaces the reference language in the editor.
	$('#referenceLanguage').change(function (e) {
		$this = $(this);
		var url = '../ReferenceLanguage/' + $this.val();

		$('#referenceWindow').load(url);
	});
	var lastEntryID;
	$('input').focus(function () {

		// TODO: Keep track of last entry worked on.
		var lastEntryID;
		if (lastEntryID != undefined)
		{
			// TODO: Perhaps this should be the time to save the last entry!
		}



		$this = $(this);
		// TODO: Keep an eye out for changes in markup.
		$this.parent().parent().css({ 'background': 'gainsboro' });
	});
	$('input').focusout(function () {
		$this = $(this);
		$this.parent().parent().css({ 'background': '' });
		var id = $this.attr('data-entry');
		var line = $this.attr('data-line');
		var text = $this.val();
		$.post("../UpdateEntry/", { id: id, line: line, text: text });
	});
});