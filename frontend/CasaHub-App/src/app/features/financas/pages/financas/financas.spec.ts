import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Financas } from './financas';

describe('Financas', () => {
  let component: Financas;
  let fixture: ComponentFixture<Financas>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Financas],
    }).compileComponents();

    fixture = TestBed.createComponent(Financas);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
