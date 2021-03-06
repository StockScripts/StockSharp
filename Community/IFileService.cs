#region S# License
/******************************************************************************************
NOTICE!!!  This program and source code is owned and licensed by
StockSharp, LLC, www.stocksharp.com
Viewing or use of this code requires your acceptance of the license
agreement found at https://github.com/StockSharp/StockSharp/blob/master/LICENSE
Removal of this comment is a violation of the license agreement.

Project: StockSharp.Community.Community
File: IFileService.cs
Created: 2015, 11, 11, 2:32 PM

Copyright 2010 by StockSharp, LLC
*******************************************************************************************/
#endregion S# License
namespace StockSharp.Community
{
	using System;
	using System.ServiceModel;

	using StockSharp.Community.Messages;

	/// <summary>
	/// The interface describing the service to work with files and documents.
	/// </summary>
	[ServiceContract(Namespace = "http://stocksharp.com/services/fileservice.svc")]
	public interface IFileService
	{
		/// <summary>
		/// To get the file data.
		/// </summary>
		/// <param name="sessionId">Session ID.</param>
		/// <param name="id">File ID.</param>
		/// <returns>The file data.</returns>
		[OperationContract]
		[Obsolete]
		FileData GetFileInfo(Guid sessionId, long id);

		/// <summary>
		/// To get the file data.
		/// </summary>
		/// <param name="sessionId">Session ID.</param>
		/// <param name="id">File ID.</param>
		/// <returns>The file data.</returns>
		[OperationContract]
		FileInfoMessage GetFileInfo2(Guid sessionId, long id);

		/// <summary>
		/// To start downloading the file.
		/// </summary>
		/// <param name="sessionId">Session ID.</param>
		/// <param name="id">File ID.</param>
		/// <returns>Operation ID.</returns>
		[OperationContract]
		[Obsolete]
		Guid BeginDownload(Guid sessionId, long id);

		/// <summary>
		/// To start downloading the file.
		/// </summary>
		/// <param name="sessionId">Session ID.</param>
		/// <param name="id">File ID.</param>
		/// <param name="compression">Use compression.</param>
		/// <returns>Operation ID.</returns>
		[OperationContract]
		Tuple<Guid, long, string> BeginDownload2(Guid sessionId, long id, bool compression);

		/// <summary>
		/// Download part of file.
		/// </summary>
		/// <param name="operationId">Operation ID, received from <see cref="BeginDownload"/>.</param>
		/// <param name="startIndex">The zero-based byte offset in file.</param>
		/// <param name="count">The maximum number of bytes to be read.</param>
		/// <returns>The part of file.</returns>
		[OperationContract]
		[Obsolete]
		byte[] ProcessDownload(Guid operationId, int startIndex, int count);

		/// <summary>
		/// Download part of file.
		/// </summary>
		/// <param name="operationId">Operation ID, received from <see cref="BeginDownload"/>.</param>
		/// <param name="startIndex">The zero-based byte offset in file.</param>
		/// <param name="count">The maximum number of bytes to be read.</param>
		/// <returns>The part of file.</returns>
		[OperationContract]
		byte[] ProcessDownload2(Guid operationId, long startIndex, int count);

		/// <summary>
		/// To finish downloading the file.
		/// </summary>
		/// <param name="operationId">Operation ID, received from <see cref="BeginDownload"/>.</param>
		/// <param name="isCancel">Cancel the operation.</param>
		[OperationContract]
		void FinishDownload(Guid operationId, bool isCancel);

		/// <summary>
		/// To start uploading the file to the site.
		/// </summary>
		/// <param name="sessionId">Session ID.</param>
		/// <param name="fileName">File name.</param>
		/// <param name="isPublic">Is the file available for public.</param>
		/// <returns>Operation ID.</returns>
		[OperationContract]
		[Obsolete]
		Guid BeginUpload(Guid sessionId, string fileName, bool isPublic);

		/// <summary>
		/// To start uploading the file to the site.
		/// </summary>
		/// <param name="sessionId">Session ID.</param>
		/// <param name="fileName">File name.</param>
		/// <param name="isPublic">Is the file available for public.</param>
		/// <param name="compression">Use compression.</param>
		/// <param name="hash">File hash.</param>
		/// <returns>Operation ID.</returns>
		[OperationContract]
		Guid BeginUpload2(Guid sessionId, string fileName, bool isPublic, bool compression, string hash);

		/// <summary>
		/// To start uploading the file to the site.
		/// </summary>
		/// <param name="sessionId">Session ID.</param>
		/// <param name="id">File ID.</param>
		/// <returns>Operation ID.</returns>
		[OperationContract]
		[Obsolete]
		Guid BeginUploadExisting(Guid sessionId, long id);

		/// <summary>
		/// To start uploading the file to the site.
		/// </summary>
		/// <param name="sessionId">Session ID.</param>
		/// <param name="id">File ID.</param>
		/// <param name="compression">Use compression.</param>
		/// <param name="hash">File hash.</param>
		/// <returns>Operation ID.</returns>
		[OperationContract]
		Guid BeginUploadExisting2(Guid sessionId, long id, bool compression, string hash);

		/// <summary>
		/// To start uploading temp file to the site.
		/// </summary>
		/// <param name="sessionId">Session ID.</param>
		/// <param name="fileName">File name.</param>
		/// <param name="compression">Use compression.</param>
		/// <param name="hash">File hash.</param>
		/// <returns>Operation ID.</returns>
		[OperationContract]
		Guid BeginUploadTemp(Guid sessionId, string fileName, bool compression, string hash);

		/// <summary>
		/// Upload part of file.
		/// </summary>
		/// <param name="operationId">Operation ID, received from <see cref="BeginUpload2"/> or <see cref="BeginUploadExisting2"/>.</param>
		/// <param name="bodyPart">The part of file.</param>
		/// <returns>The execution result code.</returns>
		[OperationContract]
		byte ProcessUpload(Guid operationId, byte[] bodyPart);

		/// <summary>
		/// To finish uploading the file.
		/// </summary>
		/// <param name="operationId">Operation ID, received from <see cref="BeginUpload2"/> or <see cref="BeginUploadExisting2"/>.</param>
		/// <param name="isCancel">Cancel the operation.</param>
		/// <returns>File ID.</returns>
		[OperationContract]
		long FinishUpload(Guid operationId, bool isCancel);

		/// <summary>
		/// Share file.
		/// </summary>
		/// <param name="sessionId">Session ID.</param>
		/// <param name="id">File ID.</param>
		/// <returns>Public token.</returns>
		[OperationContract]
		string Share(Guid sessionId, long id);

		/// <summary>
		/// Undo <see cref="Share"/> operation.
		/// </summary>
		/// <param name="sessionId">Session ID.</param>
		/// <param name="id">File ID.</param>
		[OperationContract]
		void UnShare(Guid sessionId, long id);

		/// <summary>
		/// To delete the file.
		/// </summary>
		/// <param name="sessionId">Session ID.</param>
		/// <param name="id">File ID.</param>
		/// <returns>The execution result code.</returns>
		[OperationContract]
		byte Delete(Guid sessionId, long id);

		/// <summary>
		/// To get a upload size limit.
		/// </summary>
		/// <param name="sessionId">Session ID.</param>
		/// <returns>Upload size limit.</returns>
		[OperationContract]
		long GetUploadLimit(Guid sessionId);
	}
}