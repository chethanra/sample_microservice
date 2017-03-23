import {
  Component,
  OnInit
} from '@angular/core';

import { StateService, State, City } from './state.service';
import { Title } from './title';
import { XLargeDirective } from './x-large';

@Component({
  // The selector is what angular internally uses
  // for `document.querySelectorAll(selector)` in our index.html
  // where, in this case, selector is the string 'home'
  selector: 'home',  // <home></home>
  // We need to tell Angular's Dependency Injection which providers are in our app.
  providers: [
    Title
  ],
  // Our list of styles in our component. We may add more to compose many styles together
  styleUrls: [ './home.component.css' ],
  // Every Angular template is first compiled by the browser before Angular runs it's compiler
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  // Set our default values
  public localState = { value: '' };
  // TypeScript public modifiers
  public states: State[];
  public cities: City[];

  constructor(
    public stateService: StateService,
    public title: Title
  ) {}

  public ngOnInit() {
    console.log('hello `Home` component');
    this.stateService.getStates().subscribe(response => {
      this.states = this.transformState(response.json());
      console.log(this.states);
    });
  }

  public onStateChange(stateCode: string) {
    debugger
    console.log(stateCode);
    this.stateService.getCities(stateCode).subscribe(response => {
      this.cities = this.transformCity(response.json());
      console.log(this.cities);
    });
  }

  private transformState(data: any[]) {
    let states: State[] = [];
    if(data) {
      data.forEach((state: any) => {
        states.push(new State(state.StateCode, state.StateName));
      });
    }

    return states;
  }

  private transformCity(data: any[]) {
    let cities: City[] = [];
    if(data) {
      data.forEach((city: any) => {
        cities.push(new City(city.CityCode, city.CityName, city.StateCode));
      });
    }

    return cities;
  }
}
