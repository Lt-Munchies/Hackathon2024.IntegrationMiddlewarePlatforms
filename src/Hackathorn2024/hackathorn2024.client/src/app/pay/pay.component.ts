import {Component, OnInit} from '@angular/core';
import {ApiService} from "../services/api.service";
import {Account} from "../Models/Account";

@Component({
  selector: 'app-pay',
  templateUrl: './pay.component.html',
  styleUrl: './pay.component.css'
})
export class PayComponent implements OnInit {

  accounts: Account[] = [];
  selectedAccount?: Account;

  constructor(private service: ApiService) {
    this.fileInput = document.createElement('input');
    this.fileInput.type = 'file';
    this.fileInput.addEventListener('change', this.onFileSelected.bind(this));
  }

  ngOnInit(): void {
        this.service.getAccounts().subscribe(x => {
          this.accounts = x.data.accounts;
          this.accounts = [
            {
              accountNumber: '0123',
              accountName: 'Test',
              accountId: '',
              referenceName: '',
              productName: ''
            }
          ]
        });
    }

  files: File[] = [];
  fileInput: HTMLInputElement;

  onSelectAccount() {

  }

  onFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      for (let i = 0; i < input.files.length; i++) {
        const file = input.files[i];
        this.files.push(file);
      }
    }
  }

  onDragOver(event: DragEvent) {
    event.preventDefault();
  }

  onDrop(event: DragEvent) {
    event.preventDefault();
    const files = event.dataTransfer!.files;
    for (let i = 0; i < files.length; i++) {
      const file = files[i];
      this.files.push(file);
    }
  }

  formatBytes(bytes: number, decimals = 2): string {
    if (bytes === 0) return '0 Bytes';
    const k = 1024;
    const dm = decimals < 0 ? 0 : decimals;
    const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + ' ' + sizes[i];
  }

  uploadFiles() {
    // Implement file upload logic here
    console.log('Uploading files:', this.files);
    // Clear the files array after uploading
    this.files = [];
  }

}
