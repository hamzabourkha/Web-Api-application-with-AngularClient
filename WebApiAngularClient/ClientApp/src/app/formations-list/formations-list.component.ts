import { Component, OnInit,Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-formations-list',
  templateUrl: './formations-list.component.html',
  styleUrls: ['./formations-list.component.css']
})
export class FormationsListComponent implements OnInit {

  public formations: Formation[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Formation[]>(baseUrl + 'Formations').subscribe(result => {
      this.formations = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}

interface Formation {
  id: number;
  nom: string;
  url: string;
  description: string;
  nomSeo: string;
}
