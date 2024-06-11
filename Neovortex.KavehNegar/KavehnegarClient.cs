using System.Net.Http.Json;
using System.Text.Json;
using Neovortex.KavehNegar.Dto.Requests;
using Neovortex.KavehNegar.Dto.Responses;
using Neovortex.KavehNegar.Model;
using Neovortex.KavehNegar.Utilities;

namespace Neovortex.KavehNegar;

public class KavehnegarClient
{
    private static readonly RetryOptions _retryOptionsDefault = new()
    {
        MaxTry = 5,
        WaitBetweenTriesMilliseconds = 1000
    };

    private readonly string _apiKey;
    private readonly PathBuilderUtilities _pathBuilderUtilities;
    private readonly RetryableRequest _retryableRequest;

    public KavehnegarClient(string apiKey, RetryOptions? retryItem = null)
    {
        _apiKey = apiKey;
        _pathBuilderUtilities = new PathBuilderUtilities(apiKey);
        if (retryItem == null)
            _retryableRequest = new RetryableRequest(new RetryOptions
            {
                MaxTry = _retryOptionsDefault.MaxTry,
                WaitBetweenTriesMilliseconds = _retryOptionsDefault.WaitBetweenTriesMilliseconds
            });
        else
            _retryableRequest = new RetryableRequest(new RetryOptions
            {
                MaxTry = retryItem.MaxTry,
                WaitBetweenTriesMilliseconds = retryItem.WaitBetweenTriesMilliseconds
            });
    }


    public async Task<DateTime> GetServerTime()
    {
        var result = await _retryableRequest.Invoke(async () =>
        {
            var client = new HttpClient();
            var result = await client.GetFromJsonAsync<KavehnegarTimeResponseDto>(_pathBuilderUtilities
                .BuildUri(Consts.UTILS_SCOPE_NAME, Consts.GET_DATE_METHOD_NAME));
            client.Dispose();
            return result ?? throw new InvalidOperationException("Kavehnegar response was not in expected format");
        });
        return DateTimeOffset.FromUnixTimeSeconds(result.Entries.Unixtime).DateTime;
    }

    public async Task<KavehnegarSendMessageResponseDto> Send(KavenegarSmsMessage kavenegarSmsMessage)
    {
        var result = await _retryableRequest.Invoke(async () =>
        {
            var request = KavehnegarSendMessageRequestDto
                .FromEntity(kavenegarSmsMessage);
            request.Validate();

            using var client = new HttpClient();

            var result = await client.PostAsync(
                _pathBuilderUtilities
                    .BuildUri(Consts.SEND_SMS_SCOPE_NAME, Consts.SEND_SMS_METHOD_NAME),
                request.ToFormUrlEncodedContent());
            result.EnsureSuccessStatusCode();
            var final = JsonSerializer.Deserialize<KavehnegarSendMessageResponseDto>(
                await result.Content.ReadAsStringAsync());
            if (final == null) throw new InvalidOperationException("Kavehnegar response was not in expected format");
            return final;
        });
        return result;
    }

    public async Task<KavehnegarSendMessageResponseDto> SendArray(List<KavenegarSmsMessage> kavenegarSmsMessages)
    {
        var result = await _retryableRequest.Invoke(async () =>
        {
            var request = KavehnegarSendArrayMessageRequestDto
                .FromEntity(kavenegarSmsMessages);

            request.Validate();

            using var client = new HttpClient();

            var result = await client.PostAsync(
                _pathBuilderUtilities
                    .BuildUri(Consts.SEND_SMS_SCOPE_NAME, Consts.SEND_ARRAY_SMS_METHOD_NAME),
                request.ToFormUrlEncodedContent());

            result.EnsureSuccessStatusCode();

            var final = JsonSerializer.Deserialize<KavehnegarSendMessageResponseDto>(
                await result.Content.ReadAsStringAsync());

            if (final == null) throw new InvalidOperationException("Kavehnegar response was not in expected format");

            return final;
        });
        return result;
    }

    public async Task<KavehnegarMessageStatusResponseDto> Status(List<long> messageIds)
    {
        var result = await _retryableRequest.Invoke(async () =>
        {
            var request = KavehnegarMessageStatusRequestDto
                .FromEntity(messageIds);

            request.Validate();

            using var client = new HttpClient();

            var result = await client.PostAsync(
                _pathBuilderUtilities
                    .BuildUri(Consts.SEND_SMS_SCOPE_NAME, Consts.MESSAGE_STATUS_METHOD_NAME),
                request.ToFormUrlEncodedContent());

            result.EnsureSuccessStatusCode();

            var final = JsonSerializer.Deserialize<KavehnegarMessageStatusResponseDto>(
                await result.Content.ReadAsStringAsync());

            if (final == null) throw new InvalidOperationException("Kavehnegar response was not in expected format");

            return final;
        });
        return result;
    }

    public async Task<KavehnegarMessageStatusResponseDto> StatusLocalMessageId(List<long> localMessageIds)
    {
        var result = await _retryableRequest.Invoke(async () =>
        {
            var request = KavehnegarLocalMessageIdStatusRequestDto
                .FromEntity(localMessageIds);

            request.Validate();

            using var client = new HttpClient();

            var result = await client.PostAsync(
                _pathBuilderUtilities
                    .BuildUri(Consts.SEND_SMS_SCOPE_NAME, Consts.MESSAGE_STATUS_LOCAL_MESSAGE_ID_METHOD_NAME),
                request.ToFormUrlEncodedContent());

            result.EnsureSuccessStatusCode();

            var final = JsonSerializer.Deserialize<KavehnegarMessageStatusResponseDto>(
                await result.Content.ReadAsStringAsync());

            if (final == null) throw new InvalidOperationException("Kavehnegar response was not in expected format");

            return final;
        });
        return result;
    }

    public async Task<KavehnegarMessageStatusResponseDto> Select(List<long> ids)
    {
        var result = await _retryableRequest.Invoke(async () =>
        {
            var request = KavehnegarSelectRequestDto
                .FromEntity(ids);

            request.Validate();

            using var client = new HttpClient();

            var result = await client.PostAsync(
                _pathBuilderUtilities
                    .BuildUri(Consts.SEND_SMS_SCOPE_NAME, Consts.MESSAGE_SELECT_METHOD_NAME),
                request.ToFormUrlEncodedContent());

            result.EnsureSuccessStatusCode();

            var final = JsonSerializer.Deserialize<KavehnegarMessageStatusResponseDto>(
                await result.Content.ReadAsStringAsync());

            if (final == null) throw new InvalidOperationException("Kavehnegar response was not in expected format");

            return final;
        });
        return result;
    }

    public async Task<KavehnegarMessageStatusResponseDto> SelectOutbox(SelectOutboxRequest outboxRequest)
    {
        var result = await _retryableRequest.Invoke(async () =>
        {
            var request = KavehnegarSelectOutboxRequestDto
                .FromEntity(outboxRequest.Sender, outboxRequest.Start, outboxRequest.End);

            request.Validate();

            using var client = new HttpClient();

            var result = await client.PostAsync(
                _pathBuilderUtilities
                    .BuildUri(Consts.SEND_SMS_SCOPE_NAME, Consts.MESSAGE_SELECT_OUTBOX_METHOD_NAME),
                request.ToFormUrlEncodedContent());

            result.EnsureSuccessStatusCode();

            var final = JsonSerializer.Deserialize<KavehnegarMessageStatusResponseDto>(
                await result.Content.ReadAsStringAsync());

            if (final == null) throw new InvalidOperationException("Kavehnegar response was not in expected format");

            return final;
        });
        return result;
    }

    public async Task<KavehnegarMessageStatusResponseDto> LatestOutbox(
        KavehnegarLatestOutboxRequest latestOutboxRequest)
    {
        var result = await _retryableRequest.Invoke(async () =>
        {
            var request = KavehnegarLatestOutboxRequestDto
                .FromEntity(latestOutboxRequest);

            request.Validate();

            using var client = new HttpClient();

            var result = await client.PostAsync(
                _pathBuilderUtilities
                    .BuildUri(Consts.SEND_SMS_SCOPE_NAME, Consts.MESSAGE_LATEST_OUTBOX_METHOD_NAME),
                request.ToFormUrlEncodedContent());

            result.EnsureSuccessStatusCode();

            var final = JsonSerializer.Deserialize<KavehnegarMessageStatusResponseDto>(
                await result.Content.ReadAsStringAsync());

            if (final == null) throw new InvalidOperationException("Kavehnegar response was not in expected format");

            return final;
        });
        return result;
    }

    public async Task<KavehnegarCoutOutboxResponseDto> CountOutbox(KavehnegarCoutOutboxRequest coutOutboxRequest)
    {
        var result = await _retryableRequest.Invoke(async () =>
        {
            var request = KavehnegarCoutOutboxRequestDto
                .FromEntity(coutOutboxRequest);

            request.Validate();

            using var client = new HttpClient();

            var result = await client.PostAsync(
                _pathBuilderUtilities
                    .BuildUri(Consts.SEND_SMS_SCOPE_NAME, Consts.MESSAGE_COUNT_OUTBOX_METHOD_NAME),
                request.ToFormUrlEncodedContent());

            result.EnsureSuccessStatusCode();

            var final = JsonSerializer.Deserialize<KavehnegarCoutOutboxResponseDto>(
                await result.Content.ReadAsStringAsync());

            if (final == null) throw new InvalidOperationException("Kavehnegar response was not in expected format");

            return final;
        });
        return result;
    }


    public async Task<KavehnegarCancelResponseDto> Cancel(KavenegarCancelRequest cancelRequest)
    {
        var result = await _retryableRequest.Invoke(async () =>
        {
            var request = KavenegarCancelRequestDto
                .FromEntity(cancelRequest);

            request.Validate();

            using var client = new HttpClient();

            var result = await client.PostAsync(
                _pathBuilderUtilities
                    .BuildUri(Consts.SEND_SMS_SCOPE_NAME, Consts.MESSAGE_CANCEL_METHOD_NAME),
                request.ToFormUrlEncodedContent());

            result.EnsureSuccessStatusCode();

            var final = JsonSerializer.Deserialize<KavehnegarCancelResponseDto>(
                await result.Content.ReadAsStringAsync());

            if (final == null) throw new InvalidOperationException("Kavehnegar response was not in expected format");

            return final;
        });
        return result;
    }

    public async Task<KavehnegarReceiveResponseDto> Receive(KavehnegarReceiveRequest receiveRequest)
    {
        var result = await _retryableRequest.Invoke(async () =>
        {
            var request = KavehnegarReceiveRequestDto
                .FromEntity(receiveRequest);

            request.Validate();

            using var client = new HttpClient();

            var result = await client.PostAsync(
                _pathBuilderUtilities
                    .BuildUri(Consts.SEND_SMS_SCOPE_NAME, Consts.MESSAGE_RECEIVE_METHOD_NAME),
                request.ToFormUrlEncodedContent());

            result.EnsureSuccessStatusCode();

            var final = JsonSerializer.Deserialize<KavehnegarReceiveResponseDto>(
                await result.Content.ReadAsStringAsync());

            if (final == null) throw new InvalidOperationException("Kavehnegar response was not in expected format");

            return final;
        });
        return result;
    }


    public async Task<KavehnegarCountInboxResponseDto> CountInbox(KavehnegarCountInboxRequest countInboxRequest)
    {
        var result = await _retryableRequest.Invoke(async () =>
        {
            var request = KavehnegarCountInboxRequestDto
                .FromEntity(countInboxRequest);

            request.Validate();

            using var client = new HttpClient();

            var result = await client.PostAsync(
                _pathBuilderUtilities
                    .BuildUri(Consts.SEND_SMS_SCOPE_NAME, Consts.MESSAGE_COUNT_INBOX_METHOD_NAME),
                request.ToFormUrlEncodedContent());

            result.EnsureSuccessStatusCode();

            var final = JsonSerializer.Deserialize<KavehnegarCountInboxResponseDto>(
                await result.Content.ReadAsStringAsync());

            if (final == null) throw new InvalidOperationException("Kavehnegar response was not in expected format");

            return final;
        });
        return result;
    }


    public async Task<KavehnegarLookUpResponseDto> LookUp(KavehnegarLookupRequest lookupRequest)
    {
        var result = await _retryableRequest.Invoke(async () =>
        {
            var request = KavehnegarLookupRequestDto
                .FromEntity(lookupRequest);

            request.Validate();

            using var client = new HttpClient();

            var result = await client.PostAsync(
                _pathBuilderUtilities
                    .BuildUri(Consts.VERIFY_SCOPE_NAME, Consts.LOOKUP_METHOD_NAME),
                request.ToFormUrlEncodedContent());

            result.EnsureSuccessStatusCode();

            var final = JsonSerializer.Deserialize<KavehnegarLookUpResponseDto>(
                await result.Content.ReadAsStringAsync());

            if (final == null) throw new InvalidOperationException("Kavehnegar response was not in expected format");

            return final;
        });
        return result;
    }

    public async Task<KavehnegarTtsResponseDto> TTS(KavehnegarTtsRequest lookupRequest)
    {
        var result = await _retryableRequest.Invoke(async () =>
        {
            var request = KavehnegarTtsRequestDto
                .FromEntity(lookupRequest);

            request.Validate();

            using var client = new HttpClient();

            var result = await client.PostAsync(
                _pathBuilderUtilities
                    .BuildUri(Consts.CALL_SCOPE_NAME, Consts.MAKETTS_METHOD_NAME),
                request.ToFormUrlEncodedContent());

            result.EnsureSuccessStatusCode();

            var final = JsonSerializer.Deserialize<KavehnegarTtsResponseDto>(
                await result.Content.ReadAsStringAsync());

            if (final == null) throw new InvalidOperationException("Kavehnegar response was not in expected format");

            return final;
        });
        return result;
    }


    public async Task<KavehnegarInfoResponseDto> Info()
    {
        var result = await _retryableRequest.Invoke(async () =>
        {
            using var client = new HttpClient();

            var result = await client.GetFromJsonAsync<KavehnegarInfoResponseDto>(
                _pathBuilderUtilities
                    .BuildUri(Consts.ACCOUNT_SCOPE_NAME, Consts.INFO_METHOD_NAME));

            if (result == null) throw new InvalidOperationException("Kavehnegar response was not in expected format");

            return result;
        });
        return result;
    }
}