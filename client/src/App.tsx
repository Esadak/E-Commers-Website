import React from "react";
import { Route, Switch } from 'react-router-dom';
import './sass/main.scss';
import DetailPage from './pages/DetailPage';
import Homepage from './pages/Homepage';
import LoginPage from './pages/LoginPage';
import Navigation from './components/Navigation';
import 'antd/dist/antd.css';

function App() {
  return (
    <>
      <Navigation />
      <Switch>
        <Route exact path="/" component={Homepage} />
        <Route exact path="/login" component={LoginPage} />
        <Route exact path="/detail" component={DetailPage} />
      </Switch>
    </>
  );
}

export default App;