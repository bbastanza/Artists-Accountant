import React from "react";
import { BrowserRouter as Router, Switch, Route, Redirect } from "react-router-dom";
import MyArt from "./Pages/MyArt";
import Home from "./Pages/Home";
import Login from "./Pages/Login";
import Register from "./Pages/Register";
import Analysis from "./Pages/Analysis";
import MyProfile from "./Pages/MyProfile";

const App: React.FC = () => {
    return (
        <Router>
            <Switch>
                <Route path="/myart" render={() => <MyArt />} />
                <Route path="/login" render={() => <Login />} />
                <Route path="/register" render={() => <Register />} />
                <Route path="/analysis" render={() => <Analysis />} />
                <Route path="/myprofile" render={() => <MyProfile />} />
                <Route exact path="/" render={() => <Home />} />
                <Route path="/">
                    <Redirect to="/" />
                </Route>
            </Switch>
        </Router>
    );
};

export default App;
