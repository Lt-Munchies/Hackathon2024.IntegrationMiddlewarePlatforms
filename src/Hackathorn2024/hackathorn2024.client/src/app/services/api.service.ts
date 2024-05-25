import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {AccountResponse} from "../Models/AccountResponse";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private readonly apiUrl: string = "https://localhost:7253/";

  constructor(private httpClient: HttpClient) {

  }

  getAccounts(): Observable<AccountResponse> {
    return this.httpClient.get<AccountResponse>(`${this.apiUrl}Investec`);
  }
}
