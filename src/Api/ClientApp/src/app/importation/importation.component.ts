import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-importation',
  templateUrl: './importation.component.html'
})
export class ImportationComponent {
  public importations: Importation[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Importation[]>(baseUrl + 'api/GetImportacoes').subscribe(result => {
      this.importations = result;
    }, error => console.error(error));
  }
}

interface Importation {
  id: number;
  totalItems: number;
  totalValue: number;
  lessDeliveredDate: Date;
  createdOn: Date;
}
