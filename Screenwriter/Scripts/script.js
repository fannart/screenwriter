$(function () {
	//Hiding and displaying Advanced search features
	$( '#advSearchButton' ).on('click', function() {
		$('#advancedSearch').slideToggle('slow');
	});
	//Multiple selection for dropdown
	$('#subtitleLanguages').multiselect({
		nonSelectedText: 'Subtitle Languages'
	});
	$('#mediaLanguages').multiselect({
		nonSelectedText: 'Media Languages'
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
	// Update a translation/subtitle entry when focus goes somewhere else.
	var lastEntryID;
	$('.subtitleWindow input').focusin(function () {
		$this = $(this);
		// TODO: Keep an eye out for changes in markup.
		var entry = $this.parent().parent();
		var thisEntryID = $this.attr('data-entry');
		// 
		$('#test').text('');
		//
		if (lastEntryID != thisEntryID && lastEntryID != undefined)
		{
			var subtitleID = entry.attr('data-subtitleID');
			var line1 = $('input[name="line1-' + lastEntryID + '"]').val()
			var line2 = $('input[name="line2-' + lastEntryID + '"]').val()
			var startTime = $('.entry-' + lastEntryID + ' input[name="startTime"]').val()
			var stopTime = $('.entry-' + lastEntryID + ' input[name="stopTime"]').val()
			$.post("../UpdateEntry/", {
				ID: lastEntryID,
				SubtitleID: subtitleID,
				StartTime: startTime,
				StopTime: stopTime,
				Line1: line1,
				Line2: line2
			});
		}
		lastEntryID = thisEntryID;

		$this = $(this);
		entry.css({ 'background-color': 'gainsboro' });
	});
	$('input').focusout(function () {
		$this = $(this);
		$this.parent().parent().css({ 'background-color': '' });
	});
});
