import React from "react";
import { BrowserRouter as Router, Switch, Route, Redirect } from "react-router-dom";
import MyArt from "./../Pages/MyArt";
import Home from "./../Pages/Home";
import Login from "./../Pages/Login";
import Register from "../Pages/Register";

const PageRouter: React.FC = () => {
    return (
        <Router>
            <Switch>
                <Route path="/myart" render={() => <MyArt />} />
                <Route path="/login" render={() => <Login />} />
                <Route path="/register" render={() => <Register />} />

                <Route exact path="/" render={() => <Home />} />
                <Route path="/">
                    <Redirect to="/" />
                </Route>
            </Switch>
        </Router>
    );
};

export default PageRouter;
