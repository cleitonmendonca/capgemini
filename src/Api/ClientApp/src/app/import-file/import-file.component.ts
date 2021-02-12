import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-import-file',
  templateUrl: './import-file.component.html'
})
export class ImportFileComponent {
  public importFile: ImportFile[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ImportFile[]>(baseUrl + 'api/Importar').subscribe(result => {
      this.importFile = result;
    }, error => console.error(error));
  }
}

interface ImportFile {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}