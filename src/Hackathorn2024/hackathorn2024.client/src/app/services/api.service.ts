import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {AccountResponse} from "../Models/AccountResponse";
import {UploadFileResponse} from "../Models/UploadFileResponse";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private readonly apiUrl: string = "http://localhost:5189/";

  constructor(private httpClient: HttpClient) {

  }

  getAccounts(): Observable<AccountResponse> {
    return this.httpClient.get<AccountResponse>(`${this.apiUrl}Investec`);
  }

  uploadFile(filePath: string): Observable<UploadFileResponse> {
    return this.httpClient.post<UploadFileResponse>(`${this.apiUrl}pdfChat/UploadFile?filepath=${filePath}`, null);
  }



}
