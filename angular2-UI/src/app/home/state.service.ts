import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class StateService {

  constructor(private http: Http) {

  }

  public getStates() {
    return this.http.get("http://localhost:7000/api/states");
  }

  public getCities(stateCode: string) {
    return this.http.get("http://localhost:7000/api/states/" + stateCode + "/cities");
  }

}

export class State {
  constructor(public StateCode: string, public StateName: string) {}
}  

export class City {
  constructor(public CityCode: string, public CityName: string, public StateCode: string) {}
}  
