import React, { useEffect } from "react";
import { Link } from "react-router-dom";

import TableContainer from "@mui/material/TableContainer";
import FormControlLabel from "@mui/material/FormControlLabel";
import TablePagination from "@mui/material/TablePagination";
import TableSortLabel from "@mui/material/TableSortLabel";
import FormHelperText from "@mui/material/FormHelperText";
import CssBaseline from "@mui/material/CssBaseline";
import Typography from "@mui/material/Typography";
import AlertTitle from "@mui/material/AlertTitle";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import { alpha } from "@mui/material/styles";
import Toolbar from "@mui/material/Toolbar";
import Switch from "@mui/material/Switch";
import Table from "@mui/material/Table";
import Paper from "@mui/material/Paper";
import Alert from "@mui/material/Alert";
import Box from "@mui/material/Box";

import { visuallyHidden } from "@mui/utils";

import { GetUserColleagues } from "../../services/api/Requests/UserInfoControllerRequests";
import { RefreshToken } from "../../services/api/Requests/LoginControllersRequests";
import { useJwt } from "react-jwt";
import Cookies from "js-cookie";

interface Data {
  id: number;
  username: string;
  emailAddress: string;
  firstName: string;
  lastName: string;
  dateOfBirth: string;
  seniority: string;
  role: string;
}

function createData(
  id: number,
  username: string,
  emailAddress: string,
  firstName: string,
  lastName: string,
  dateOfBirth: string,
  seniority: string,
  role: string
): Data {
  return {
    id,
    username,
    emailAddress,
    firstName,
    lastName,
    dateOfBirth,
    seniority,
    role,
  };
}

function descendingComparator<T>(a: T, b: T, orderBy: keyof T) {
  if (b[orderBy] < a[orderBy]) {
    return -1;
  }
  if (b[orderBy] > a[orderBy]) {
    return 1;
  }
  return 0;
}

type Order = "asc" | "desc";

function getComparator<Key extends keyof any>(
  order: Order,
  orderBy: Key
): (
  a: { [key in Key]: number | string },
  b: { [key in Key]: number | string }
) => number {
  return order === "desc"
    ? (a, b) => descendingComparator(a, b, orderBy)
    : (a, b) => -descendingComparator(a, b, orderBy);
}

// This method is created for cross-browser compatibility, if you don't
// need to support IE11, you can use Array.prototype.sort() directly
function stableSort<T>(
  array: readonly T[],
  comparator: (a: T, b: T) => number
) {
  const stabilizedThis = array.map((el, index) => [el, index] as [T, number]);
  stabilizedThis.sort((a, b) => {
    const order = comparator(a[0], b[0]);
    if (order !== 0) {
      return order;
    }
    return a[1] - b[1];
  });
  return stabilizedThis.map((el) => el[0]);
}

interface HeadCell {
  id: keyof Data;
  numeric: boolean;
  disablePadding: boolean;
  label: string;
}

const headCells: readonly HeadCell[] = [
  {
    id: "username",
    numeric: false,
    disablePadding: false,
    label: "Username",
  },
  {
    id: "emailAddress",
    numeric: false,
    disablePadding: false,
    label: "E-mail",
  },
  {
    id: "firstName",
    numeric: false,
    disablePadding: false,
    label: "First name",
  },
  {
    id: "lastName",
    numeric: false,
    disablePadding: false,
    label: "Last name",
  },
  {
    id: "dateOfBirth",
    numeric: false,
    disablePadding: false,
    label: "Date of birth",
  },
  {
    id: "seniority",
    numeric: false,
    disablePadding: false,
    label: "Seniority",
  },
  {
    id: "role",
    numeric: false,
    disablePadding: false,
    label: "Role",
  },
];

interface EnhancedTableProps {
  numSelected: number;
  onRequestSort: (
    event: React.MouseEvent<unknown>,
    property: keyof Data
  ) => void;
  onSelectAllClick: (event: React.ChangeEvent<HTMLInputElement>) => void;
  order: Order;
  orderBy: string;
  rowCount: number;
}

function EnhancedTableHead(props: EnhancedTableProps) {
  const { order, orderBy, onRequestSort } = props;
  const createSortHandler =
    (property: keyof Data) => (event: React.MouseEvent<unknown>) => {
      onRequestSort(event, property);
    };

  return (
    <TableHead>
      <TableRow>
        {headCells.map((headCell) => (
          <TableCell
            key={headCell.id}
            align={"left"}
            padding={headCell.disablePadding ? "none" : "normal"}
            sortDirection={orderBy === headCell.id ? order : false}
          >
            <TableSortLabel
              active={orderBy === headCell.id}
              direction={orderBy === headCell.id ? order : "asc"}
              onClick={createSortHandler(headCell.id)}
            >
              {headCell.label}
              {orderBy === headCell.id ? (
                <Box component="span" sx={visuallyHidden}>
                  {order === "desc" ? "sorted descending" : "sorted ascending"}
                </Box>
              ) : null}
            </TableSortLabel>
          </TableCell>
        ))}
      </TableRow>
    </TableHead>
  );
}

interface EnhancedTableToolbarProps {
  numSelected: number;
  selectedId: number[];
}

const EnhancedTableToolbar = (props: EnhancedTableToolbarProps) => {
  const { numSelected } = props;

  return (
    <Toolbar
      sx={{
        pl: { sm: 2 },
        pr: { xs: 1, sm: 1 },
        ...(numSelected > 0 && {
          bgcolor: (theme) =>
            alpha(
              theme.palette.primary.main,
              theme.palette.action.activatedOpacity
            ),
        }),
      }}
    >
      <Typography
        sx={{ flex: "1 1 100%" }}
        variant="h6"
        id="tableTitle"
        component="div"
      >
        Colleagues
      </Typography>
    </Toolbar>
  );
};

export default function ColleaguesTable() {
  const [errorText, setErrorText] = React.useState("");
  const [rows, setRows] = React.useState([]);
  const [order, setOrder] = React.useState<Order>("asc");
  const [orderBy, setOrderBy] = React.useState<keyof Data>("id");
  const [selected, setSelected] = React.useState<number[]>([]);
  const [page, setPage] = React.useState(0);
  const [dense, setDense] = React.useState(false);
  const [rowsPerPage, setRowsPerPage] = React.useState(10);
  const { decodedToken, isExpired, reEvaluateToken } = useJwt(
    Cookies.get("user_session")
  );

  useEffect(() => {
    const refreshToken = async () => {
      let isSuccessfully = await RefreshToken();
      if (isSuccessfully) {
        reEvaluateToken(Cookies.get("user_session"));
      }
    };

    const getEmployees = async () => {
      let employees = await GetUserColleagues();
      if (employees) {
        setRows(
          employees.map((item: any) => {
            return createData(
              item.id,
              item.username,
              item.emailAddress,
              item.firstName,
              item.lastName,
              item.dateOfBirth.slice(0, 10),
              item.seniority,
              item.role
            );
          })
        );
      } else {
        setErrorText("The user has no colleagues");
      }
    };

    if (decodedToken) {
      if (isExpired) {
        refreshToken();
      }
      getEmployees();
    }
  });

  const handleRequestSort = (
    event: React.MouseEvent<unknown>,
    property: keyof Data
  ) => {
    const isAsc = orderBy === property && order === "asc";
    setOrder(isAsc ? "desc" : "asc");
    setOrderBy(property);
  };

  const handleSelectAllClick = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.checked) {
      const newSelected = rows.map((n) => n.id);
      setSelected(newSelected);
      return;
    }
    setSelected([]);
  };

  const handleChangePage = (event: unknown, newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  const handleChangeDense = (event: React.ChangeEvent<HTMLInputElement>) => {
    setDense(event.target.checked);
  };

  // Avoid a layout jump when reaching the last page with empty rows.
  const emptyRows =
    page > 0 ? Math.max(0, (1 + page) * rowsPerPage - rows.length) : 0;

  return (
    <Box sx={{ width: "100%", px: "20px", pt: "20px" }}>
      <CssBaseline />
      <Paper sx={{ width: "100%", mb: 2 }}>
        <EnhancedTableToolbar
          numSelected={selected.length}
          selectedId={selected}
        />
        <TableContainer>
          <Table
            sx={{ minWidth: 750 }}
            aria-labelledby="tableTitle"
            size={dense ? "small" : "medium"}
          >
            <EnhancedTableHead
              numSelected={selected.length}
              order={order}
              orderBy={orderBy}
              onSelectAllClick={handleSelectAllClick}
              onRequestSort={handleRequestSort}
              rowCount={rows.length}
            />
            <TableBody>
              {/* if you don't need to support IE11, you can replace the `stableSort` call with:
              rows.slice().sort(getComparator(order, orderBy)) */}
              {stableSort(rows, getComparator(order, orderBy))
                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                .map((row) => {
                  return (
                    <TableRow key={row.id}>
                      <TableCell>{row.username}</TableCell>
                      <TableCell>{row.emailAddress}</TableCell>
                      <TableCell>{row.firstName}</TableCell>
                      <TableCell>{row.lastName}</TableCell>
                      <TableCell>{row.dateOfBirth}</TableCell>
                      <TableCell>{row.seniority}</TableCell>
                      <TableCell>{row.role}</TableCell>
                    </TableRow>
                  );
                })}
              {emptyRows > 0 && (
                <TableRow
                  style={{
                    height: (dense ? 33 : 53) * emptyRows,
                  }}
                >
                  <TableCell colSpan={10} />
                </TableRow>
              )}
            </TableBody>
          </Table>
        </TableContainer>
        <TablePagination
          rowsPerPageOptions={[10, 25, 50]}
          component="div"
          count={rows.length}
          rowsPerPage={rowsPerPage}
          page={page}
          onPageChange={handleChangePage}
          onRowsPerPageChange={handleChangeRowsPerPage}
        />
      </Paper>
      <FormControlLabel
        control={<Switch checked={dense} onChange={handleChangeDense} />}
        label="Dense padding"
      />
      {errorText && (
        <FormHelperText error sx={{ mt: 5 }}>
          <Alert severity="error">
            <AlertTitle>Error</AlertTitle>
            {errorText}
          </Alert>
        </FormHelperText>
      )}
    </Box>
  );
}
